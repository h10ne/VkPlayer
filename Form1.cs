using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.IO;
using WMPLib;
using System.Drawing.Text;
using System.Drawing;

namespace VkPlayer
{
    public partial class Main : Form
    {
        WMPLib.WindowsMediaPlayer player;
        public string _Login;
        public string _Password;
        private long user_id;
        public string Token = null;
        private static IVkApi api;
        private ServiceCollection service;
        public Font Roboto_medium;
        public Font Roboto_thin;
        private Color MainColor;
        private Color addColor;
        private int countAudio;
        Random rnd;
        private bool repeat = false;
        private bool random = false;
        private int _offset = 0;
        private string _URL;
        private bool isPlay = false;
        private bool mute = false;
        public Main()
        {
            InitializeComponent();
            try
            {
                Token = File.ReadAllText("auth.dat");
                TryAuth();
            }
            catch { }
            if (_Login == null && _Password == null && Token == null)
                TryAuth();

            player = new WindowsMediaPlayer();
            duration_timer.Stop();
            SetInfo();
            LoadText();
            artist_name.Font = Roboto_medium;
            title_name.Font = Roboto_thin;
            MainColor = Color.FromArgb(255, 63, 81, 181);
            addColor = Color.FromArgb(255, 48, 63, 159);
            BackColor = MainColor;
            KeyPreview = true;

        }
        
        public void LoadText()
        {
            try
            {
                PrivateFontCollection font = new PrivateFontCollection();
                font.AddFontFile("Roboto-Medium.ttf");
                font.AddFontFile("Roboto-Light.ttf");
                Roboto_medium = new Font(font.Families[0], 12);
                Roboto_thin = new Font(font.Families[1], 12);
            }
            catch { }
        }

        public void GetAllEnabled()
        {
            volume.Enabled = true;
            play_pause_btn.Enabled = true;
            back_btn.Enabled = true;
            next_btn.Enabled = true;
            duration_bar.Enabled = true;
            artist_name.Enabled = true;
            title_name.Enabled = true;
        }

        public void GetAuth()
        {
            service = new ServiceCollection();
            service.AddAudioBypass();
            api = new VkApi(service);
            if (Token == null)
            {
                api.Authorize(new ApiAuthParams
                {
                    Login = _Login,
                    Password = _Password,
                });
                user_id = api.UserId.GetHashCode();
                File.WriteAllText("user_id.dat", user_id.ToString());
                Show();
            }
            else
            {
                api.Authorize(new ApiAuthParams
                {
                    AccessToken = Token
                });
                user_id = long.Parse (File.ReadAllText("user_id.dat"));
            }
            rnd = new Random();
            countAudio = (int)api.Audio.GetCount(user_id);
            File.WriteAllText("auth.dat", api.Token);
            GetAllEnabled();
        }

        public void TryAuth()
        {
            if (_Password == null && _Login == null && Token == null)
            {
                authorization_form f = new authorization_form
                {
                    Owner = this
                };
                f.ShowDialog();
            }
            else
                GetAuth();
        }
        private void SetInfo()
        {            
            var audio = api.Audio.Get(new AudioGetParams { Count = 1, Offset = _offset });
            try
            {
                _URL = audio[0].Url.ToString();
                player.URL = _URL;
                player.controls.stop();
                artist_name.Text = audio[0].Artist;
                title_name.Text = audio[0].Title;
                player.settings.volume = volume.Value;
                duration_timer.Start();
                duration_bar.Value = 0;
            }
            catch { }
        }
        
        private void play_pause()
        {
            if (isPlay)
            {
                player.controls.pause();
                play_pause_btn.Image = Resource1.play;
                isPlay = false;
            }
            else
            {
                player.controls.play();
                play_pause_btn.Image = Resource1.pause;
                isPlay = true;
            }
        }

        private void play_pause_btn_Click(object sender, EventArgs e)
        {
            play_pause();
        }

        private void volume_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volume.Value;
        }
        private void back_btn_Click(object sender, EventArgs e)
        {
            prevSong();
        }

        private void prevSong()
        {
            if (_offset != 0)
            {
                _offset--;
            }
            SetInfo();
            if (isPlay)
            {
                player.controls.play();
            }
            else
            {
                player.controls.pause();
            }
        }
        private void NextSong()
        {
            if (random)
            {
                _offset = rnd.Next(0, countAudio);
            }
            if (api.Audio.GetCount(user_id) > _offset)
            {
                _offset++;
            }
            else
            {
                _offset = 0;
            }
            SetInfo();
            if (isPlay)
            {
                player.controls.play();
            }
            else
            {
                player.controls.pause();
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            NextSong();
        }        
        private void duration_timer_Tick(object sender, EventArgs e)
        {
            duration_bar.Maximum = (int)player.currentMedia.duration;
            duration_bar.Value = (int)player.controls.currentPosition;
        }
       
        private void duration_bar_Scroll(object sender, EventArgs e)
        {
            duration_bar.Maximum = (int)player.currentMedia.duration;
            player.controls.currentPosition = duration_bar.Value;            
        }
        private void timerForRefresh_Tick(object sender, EventArgs e)
        {
            if (Token!=null && artist_name.Text=="artist" && title_name.Text=="title")
            {
                SetInfo();
            }
            if (artist_name.Text != "artist" && title_name.Text != "title")
            {
                timerForRefresh.Stop();
                NextSongTimer.Start();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("auth.dat");
            System.Windows.Forms.Application.Restart();
            Close();
        }

        private void NextSongTimer_Tick(object sender, EventArgs e)
        {
            if (player.status == "Остановлено")
            {
                if (!repeat)
                    NextSong();
                else
                {
                    player.controls.play();
                }
            }
        }

        private void repeat_radio_Click(object sender, EventArgs e)
        {
            if (repeat == false)
            {
                repeat = true;
                repeat_radio.BackColor = addColor;
            }
            else
            {
                repeat = false;
                repeat_radio.BackColor = MainColor;
            }
        }

        private void random_radio_Click(object sender, EventArgs e)
        {
            if (random == false)
            {
                random = true;
                random_radio.BackColor = addColor;
            }
            else
            {
                random = false;
                random_radio.BackColor = MainColor;
            }
            
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                play_pause();
            }
            else if(e.KeyCode == Keys.Up)
            {
                if (volume.Value + 5 < volume.Maximum)
                {
                    player.settings.volume += 5;
                    volume.Value += 5;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (volume.Value - 5 > volume.Minimum)
                {
                    player.settings.volume -= 5;
                    volume.Value -= 5;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                prevSong();
            }
            else if (e.KeyCode == Keys.Right)
            {
                NextSong();
            }
            else if (e.KeyCode == Keys.M)
            {
                SetMute_Unmute();
            }
        }

        private void artist_name_Click(object sender, EventArgs e)
        {

        }
        

        private void SetMute_Unmute()
        {
            if (mute)
            {
                player.settings.mute = false;
                mute = false;
                mute_unmute.Image = Resource1.unmute;
            }
            else
            {
                player.settings.mute = true;
                mute = true;
                mute_unmute.Image = Resource1.mute;
            }
        }

        private void mute_unmute_Click(object sender, EventArgs e)
        {
            SetMute_Unmute();
        }

        private void ShowColors()
        {
            colorAmber_btn.Visible = true;
            colorBlueGrey_btn.Visible = true;
            colorBlue_btn.Visible = true;
            colorBrown_btn.Visible = true;
            colorCyan_btn.Visible = true;
            colorDeepOrange_btn.Visible = true;
            colorDeepPurple_btn.Visible = true;
            colorGreen_btn.Visible = true;
            colorIndigo_btn.Visible = true;
            colorLime_btn.Visible = true;
            colorOrange_btn.Visible = true;
            colorPurple_btn.Visible = true;
            ColorRed_btn.Visible = true;
            ColorRed_btn.Visible = true;
            colorTeal_btn.Visible = true;
            colorYellow_btn.Visible = true;
        }

        private void HideColors()
        {
            colorAmber_btn.Visible = false;
            colorBlueGrey_btn.Visible = false;
            colorBlue_btn.Visible = false;
            colorBrown_btn.Visible = false;
            colorCyan_btn.Visible = false;
            colorDeepOrange_btn.Visible = false;
            colorDeepPurple_btn.Visible = false;
            colorGreen_btn.Visible = false;
            colorIndigo_btn.Visible = false;
            colorLime_btn.Visible = false;
            colorOrange_btn.Visible = false;
            colorPurple_btn.Visible = false;
            ColorRed_btn.Visible = false;
            ColorRed_btn.Visible = false;
            colorTeal_btn.Visible = false;
            colorYellow_btn.Visible = false;
        }

        private void SetColors(Color mainColor, Color addColor)
        {
            this.BackColor = mainColor;
            this.MainColor = mainColor;
            this.addColor = addColor;
            if (repeat)
            {
                repeat_radio.BackColor = addColor;
            }
            if (random)
            {
                random_radio.BackColor = addColor;
            }
        }

        private void SelectColor_btn_Click(object sender, EventArgs e)
        {
            if (colorYellow_btn.Visible == true)
            {
                HideColors();
            }
            else
            {
                ShowColors();
            }
        }

        private void ColorRed_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 229, 57, 53);
            Color add = Color.FromArgb(255, 183, 28, 28);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorPurple_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 171, 71, 188);
            Color add = Color.FromArgb(255, 123, 31, 162);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorDeepPurple_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 103, 58, 183);
            Color add = Color.FromArgb(255, 69, 39, 160);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorIndigo_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 63, 81, 181);
            Color add = Color.FromArgb(255, 40, 53, 147);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorBlue_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 33, 150, 243);
            Color add = Color.FromArgb(255, 21, 101, 192);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorCyan_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 198, 218);
            Color add = Color.FromArgb(255, 0, 151, 167);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorTeal_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 166, 154);
            Color add = Color.FromArgb(255, 0, 121, 107);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorGreen_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 76, 175, 80);
            Color add = Color.FromArgb(255, 46, 125, 50);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorLime_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 205, 220, 57);
            Color add = Color.FromArgb(255, 175, 180, 43);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorYellow_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 238, 88);
            Color add = Color.FromArgb(255, 253, 216, 53);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorAmber_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 202, 40);
            Color add = Color.FromArgb(255, 255, 179, 0);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorOrange_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 152, 0);
            Color add = Color.FromArgb(255, 245, 124, 0);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            SetColors(main, add);
            HideColors();
        }

        private void colorDeepOrange_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 87, 34);
            Color add = Color.FromArgb(255, 216, 67, 21);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorBrown_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 121, 85, 72);
            Color add = Color.FromArgb(255, 93, 64, 55);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }

        private void colorBlueGrey_btn_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 120, 144, 156);
            Color add = Color.FromArgb(255, 69, 90, 100);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            SetColors(main, add);
            HideColors();
        }
    }
}
