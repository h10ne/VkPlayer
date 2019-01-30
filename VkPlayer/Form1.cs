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
using System.Collections.Generic;
namespace VkPlayer
{
    public partial class Main : Form
    {
        WMPLib.WindowsMediaPlayer player;
        private long user_id;
        public string Token = null;
        private static IVkApi api;
        private ServiceCollection service;
        public Font Roboto_medium;
        public Font Roboto_thin;
        private Color MainColor;
        private Color addColor;
        public string code = null;
        Random rnd;
        bool customSong = false;
        private VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> searchAudios;
        private int clr;
        private bool repeat = false;
        private bool random = false;
        private int _offset = 0;
        private bool isPlay = false;
        private bool mute = false;
        private bool isBlack = false;
        private bool isFind = false;
        public Main()
        {
            InitializeComponent();
            if (File.Exists("auth.dat"))
            {
                Token = File.ReadAllText("auth.dat");
                GetAuth(false);
            }
            else
            {
                authorization_form f = new authorization_form
                {
                    Owner = this
                };
                f.ShowDialog();
            }
            player = new WindowsMediaPlayer();
            duration_timer.Stop();
            SetAudioInfo();
            LoadText();
            play_pause_btn.Image = Resource1.play;
            artist_name.Font = Roboto_medium;
            title_name.Font = Roboto_thin;
            MainColor = Color.FromArgb(255, 63, 81, 181);
            addColor = Color.FromArgb(255, 48, 63, 159);
            if (File.Exists("user_color.dat"))
            {
                byte darkTheme = 20; 
                string[] vs = File.ReadAllText("user_color.dat").Split(' ');
                MainColor = Color.FromArgb(255, byte.Parse(vs[0]), byte.Parse(vs[1]), byte.Parse(vs[2]));
                addColor = Color.FromArgb(255, byte.Parse(vs[3]), byte.Parse(vs[4]), byte.Parse(vs[5]));
                if (byte.Parse(vs[0]) == darkTheme)
                {
                    isBlack = true;
                    SetColors(MainColor, addColor);
                }
                if (byte.Parse(vs[6]) == 0)
                {
                    artist_name.ForeColor = Color.Black;
                    title_name.ForeColor = Color.Black;
                    AudioList.ForeColor = Color.Black;
                    searchAudio_box.ForeColor = Color.Black;
                }
                else
                {
                    artist_name.ForeColor = Color.White;
                    title_name.ForeColor = Color.White;
                    AudioList.ForeColor = Color.White;
                    searchAudio_box.ForeColor = Color.White;
                }
            }
            BackColor = MainColor;
            KeyPreview = true;
            this.ContextMenuStrip = Menu;
            isPlay = false;
            if (isBlack)
                play_pause_btn.Image = Resource1.play_white;
            else
                play_pause_btn.Image = Resource1.play;
            play_pause_btn.Focus();
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

        private void AuthToken()
        {
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token
            });
            user_id = long.Parse(File.ReadAllText("user_id.dat"));
        }

        private void Auth2Fact(string login, string password)
        {
            api.Authorize(new ApiAuthParams
            {
                Login = login,
                Password = password,
                TwoFactorAuthorization = () =>
                {
                    AuthForm2 f = new AuthForm2();
                    f.ShowDialog();
                    while (code == null)
                    {
                        code = File.ReadAllText("someFile.tempdat");
                    }
                    System.IO.File.Delete("someFile.tempdat");
                    return code;
                }
            });
            user_id = api.UserId.GetHashCode();
            File.WriteAllText("user_id.dat", user_id.ToString());
            File.WriteAllText("auth.dat", api.Token);
            Show();
        }

        private void AuthLogPass(string login, string password)
        {
            api.Authorize(new ApiAuthParams
            {
                Login = login,
                Password = password,
            });
            user_id = api.UserId.GetHashCode();
            File.WriteAllText("user_id.dat", user_id.ToString());
            File.WriteAllText("auth.dat", api.Token);
            Show();
        }

        public void GetAuth(bool twoFactoringCode, string login = null, string password = null)
        {
            service = new ServiceCollection();
            service.AddAudioBypass();
            api = new VkApi(service);
            if (Token == null && !twoFactoringCode)
            {
                AuthLogPass(login, password);
            }
            else if (twoFactoringCode)
            {
                Auth2Fact(login, password);
            }
            else
            {
                AuthToken();
            }
            rnd = new Random();

        }        

        private void SetAudioInfo()
        {
            var audio = api.Audio.Get(new AudioGetParams { Count = 1, Offset = _offset });
            int tempOffset = _offset;
            while (audio[0].Url == null) 
            {
                ++_offset;
                if (tempOffset == _offset)
                    _offset-=2;
                tempOffset = _offset;
                audio = api.Audio.Get(new AudioGetParams { Count = 1, Offset = _offset });
            }
            player.URL = audio[0].Url.ToString();
            artist_name.Text = audio[0].Artist;
            title_name.Text = audio[0].Title;
            player.settings.volume = volume.Value;
            duration_timer.Start();
            duration_bar.Value = 0;
            if (isBlack)
                play_pause_btn.Image = Resource1.pause_white;
            else
                play_pause_btn.Image = Resource1.pause;
            isPlay = true;
        }
        
        private void play_pause()
        {
            if (!isPlay)
            {
                player.controls.play();
                if (!isBlack)
                    play_pause_btn.Image = Resource1.pause;
                else
                    play_pause_btn.Image = Resource1.pause_white;
                isPlay = true;
            }
            else
            {
                player.controls.pause();
                if (!isBlack)
                    play_pause_btn.Image = Resource1.play;
                else
                    play_pause_btn.Image = Resource1.play_white;
                isPlay = false;
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
            PrevSong();
        }

        private void PrevSong()
        {
            if (!customSong)
            {
                if (_offset != 0)
                {
                    _offset--;
                }
                SetAudioInfo();
            }
            else
            {
                try
                {

                    AudioList.SelectedIndex -= 1;
                    searchSetInfo();
                }
                catch
                {
                    AudioList.SelectedIndex += 1;
                    searchSetInfo();
                }
            }
        }
        private void NextSong()
        {
            if (!customSong)
            {
                if (random)
                {
                    _offset = rnd.Next(0, (int)api.Audio.GetCount(user_id));
                }
                if (api.Audio.GetCount(user_id) > _offset)
                {
                    _offset++;
                }
                else
                {
                    _offset = 0;
                }
                SetAudioInfo();
            }
            else
            {


                if (random)
                {
                    Random rnds = new Random();
                    int value = rnds.Next(0,19);
                    AudioList.SelectedIndex = value; try
                    {
                        searchSetInfo();
                    }
                    catch
                    {
                        //AudioList.SelectedIndex = 0;
                        //searchSetInfo();
                    }
                }
                else
                {
                    AudioList.SelectedIndex += 1;
                    searchSetInfo();
                }
                
            }

        }        

        private void next_btn_Click(object sender, EventArgs e)
        {
            NextSong();
        }        
        private void duration_timer_Tick(object sender, EventArgs e)
        {
            if (searchAudio_box.Text == "")
                customSong = false;
            duration_bar.Maximum = (int)player.currentMedia.duration;
            duration_bar.Value = (int)player.controls.currentPosition;
            currentTimeDur.Text = player.controls.currentPositionString;
            AllTimeDur.Text = player.currentMedia.durationString;
        }
       
        private void duration_bar_Scroll(object sender, EventArgs e)
        {
            duration_bar.Maximum = (int)player.currentMedia.duration;
            player.controls.currentPosition = duration_bar.Value;
            currentTimeDur.Text = player.controls.currentPositionString;
        }
        private void timerForRefresh_Tick(object sender, EventArgs e)
        {
            if (Token!=null && artist_name.Text=="artist" && title_name.Text=="title")
            {
                SetAudioInfo();
            }
            if (artist_name.Text != "artist" && title_name.Text != "title")
            {
                timerForRefresh.Stop();
                player.controls.stop();
                NextSongTimer.Start();
                AllTimeDur.Text = player.currentMedia.durationString;
                next_btn.Focus();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("auth.dat");
            System.IO.File.Delete("user_id.dat");
            System.IO.File.Delete("user_color.dat");
            System.Windows.Forms.Application.Restart();
            Close();
        }

        private void NextSongTimer_Tick(object sender, EventArgs e)
        {
            if (player.status == "Остановлено")
            {
                if (!customSong)
                {
                    if (!repeat)
                        NextSong();
                    else
                    {
                        player.controls.play();
                    }
                }
                else
                {
                    if (!repeat)
                        try
                        {
                            AudioList.SelectedIndex += 1; ;
                            searchSetInfo();
                        }
                        catch { }
                    else
                    {
                        Random rnds = new Random();
                        int value = rnds.Next(0, 19);
                        AudioList.SelectedIndex = value;
                        searchSetInfo();
                    }
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
            if (!searchAudio_box.Focused && !AudioList.Focused)
            {
                if (e.KeyCode == Keys.Space)
                {
                    play_pause();
                }
                else if (e.KeyCode == Keys.Up)
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
                    PrevSong();
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
        }

        private void SetMute_Unmute()
        {
            if (mute)
            {
                player.settings.mute = false;
                mute = false;
                if (!isBlack)
                    mute_unmute.Image = Resource1.unmute;
                else
                    mute_unmute.Image = Resource1.unmute_white;
            }
            else
            {
                player.settings.mute = true;
                mute = true;
                if (!isBlack)
                    mute_unmute.Image = Resource1.mute;
                else
                    mute_unmute.Image = Resource1.mute_white;
            }
        }

        private void mute_unmute_Click(object sender, EventArgs e)
        {
            SetMute_Unmute();
        }

        private void SetColors(Color mainColor, Color addColor, bool black = true)
        {   
            if (isBlack)
            {
                if (isPlay)
                    play_pause_btn.Image = Resource1.pause_white;
                else
                    play_pause_btn.Image = Resource1.play_white;
                next_btn.Image = Resource1.next_white;
                back_btn.Image = Resource1.prev_white;
                Logout.Image = Resource1.door_white;
                find_btn.Image = Resource1.find_white;
                if (mute)
                    mute_unmute.Image = Resource1.mute_white;
                else
                    mute_unmute.Image = Resource1.unmute_white;
                repeat_radio.Image = Resource1.repeat_white;
                random_radio.Image = Resource1.random_white;
                currentTimeDur.ForeColor = Color.White;
                AllTimeDur.ForeColor = Color.White;
            }

            if (!black && isBlack)
            {
                isBlack = false;

                if (isPlay)
                    play_pause_btn.Image = Resource1.pause;
                else
                    play_pause_btn.Image = Resource1.play;
                next_btn.Image = Resource1.next;
                back_btn.Image = Resource1.prev;
                Logout.Image = Resource1.door;
                find_btn.Image = Resource1.find;
                if (mute)
                    mute_unmute.Image = Resource1.mute;
                else
                    mute_unmute.Image = Resource1.unmute;
                repeat_radio.Image = Resource1.repeat;
                random_radio.Image = Resource1.random;
                currentTimeDur.ForeColor = Color.Black;
                AllTimeDur.ForeColor = Color.Black;
            }

            this.BackColor = mainColor;
            this.MainColor = mainColor;
            this.addColor = addColor;
            AudioList.BackColor = addColor;
            searchAudio_box.BackColor = addColor;
            if (repeat)
            {
                repeat_radio.BackColor = addColor;
            }
            else
            {
                repeat_radio.BackColor = mainColor;
            }
            if (random)
            {
                random_radio.BackColor = addColor;
            }
            else
            {
                random_radio.BackColor = mainColor;
            }
            if (artist_name.ForeColor.B == 0)
                clr = 0;
            else
                clr = 255;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("user_color.dat", $"{MainColor.R} {MainColor.G} {MainColor.B} {addColor.R} {addColor.G} {addColor.B} {clr}");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 229, 57, 53);
            Color add = Color.FromArgb(255, 183, 28, 28);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 171, 71, 188);
            Color add = Color.FromArgb(255, 123, 31, 162);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void deepPurpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 103, 58, 183);
            Color add = Color.FromArgb(255, 69, 39, 160);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void indigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 63, 81, 181);
            Color add = Color.FromArgb(255, 40, 53, 147);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 33, 150, 243);
            Color add = Color.FromArgb(255, 21, 101, 192);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void cyanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 198, 218);
            Color add = Color.FromArgb(255, 0, 151, 167);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void tealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 166, 154);
            Color add = Color.FromArgb(255, 0, 121, 107);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 76, 175, 80);
            Color add = Color.FromArgb(255, 46, 125, 50);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void limeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 205, 220, 57);
            Color add = Color.FromArgb(255, 175, 180, 43);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 238, 88);
            Color add = Color.FromArgb(255, 253, 216, 53);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void amberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 202, 40);
            Color add = Color.FromArgb(255, 255, 179, 0);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 152, 0);
            Color add = Color.FromArgb(255, 245, 124, 0);
            artist_name.ForeColor = Color.Black;
            title_name.ForeColor = Color.Black;
            AudioList.ForeColor = Color.Black;
            searchAudio_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }

        private void deepOrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 87, 34);
            Color add = Color.FromArgb(255, 216, 67, 21);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 121, 85, 72);
            Color add = Color.FromArgb(255, 93, 64, 55);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void blueGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 120, 144, 156);
            Color add = Color.FromArgb(255, 69, 90, 100);
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isBlack = true;            
            artist_name.ForeColor = Color.White;
            title_name.ForeColor = Color.White;
            AudioList.ForeColor = Color.White;
            searchAudio_box.ForeColor = Color.White;
            Color main = Color.FromArgb(255, 20, 20, 20);
            Color add = Color.FromArgb(255, 50, 50, 50);
            SetColors(main, add);
        }

        private void searchAudio_KeyDown(object sender, KeyEventArgs e)
        {
            AudioList.Items.Clear();            
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    searchAudios = api.Audio.Search(new AudioSearchParams
                    {
                        Query = searchAudio_box.Text,
                        Autocomplete = true,
                        SearchOwn = true,
                        Count = 20,
                        PerformerOnly = false
                    });

                    foreach (var audio in searchAudios)
                        AudioList.Items.Add($"{audio.Artist} - {audio.Title}");
                }
                catch { }
            }
        }

        void searchSetInfo()
        {            
            string selectItem = AudioList.SelectedItem.ToString();
            int index = 0;
            for (int i = 0; i < selectItem.Length; i++)
            {
                if (selectItem[i] == ' ' && selectItem[i + 1] == '-' && selectItem[i + 2] == ' ')
                {
                    index = i;
                    break;
                }

            }
            string artist = selectItem.Substring(0, index);
            string title = selectItem.Substring(index + 3);
            foreach (var audio in searchAudios)
                if (audio.Artist == artist && audio.Title == title)
                {
                    player.URL = audio.Url.ToString();
                    artist_name.Text = artist;
                    title_name.Text = title;
                    player.controls.play();
                }
            if (isBlack)
                play_pause_btn.Image = Resource1.pause_white;
            else
                play_pause_btn.Image = Resource1.pause;
            isPlay = true;
        }

        private void AudioList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                customSong = true;
                searchSetInfo();
            }
            catch { }
            next_btn.Focus();
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            next_btn.Focus();
        }

        private void AudioList_MouseClick(object sender, MouseEventArgs e)
        {
            next_btn.Focus();
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            if (isFind)
            {
                Width = 365;
                isFind = false;
            }
            else
            {
                Width = 521;
                isFind = true;
            }
            play_pause_btn.Focus();
        }
    }
}
