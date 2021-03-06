﻿using System;
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
using VkNet.Enums.Filters;

namespace VkPlayer
{
    public partial class Main : Form
    {
        public WMPLib.WindowsMediaPlayer player;
        public string Token = null;
        public IVkApi api;
        public Font Roboto_medium;
        public Font Roboto_thin;
        public Font Roboto_thin_10;
        private Color MainColor;
        private Color addColor;
        public string code = null;
        public Random rnd;
        private int clr;
        Playlist playlist;
        public Switches VkBools;
        public VkDatas vkDatas;
        public bool isAuth = false;
        public Main()
        {
            InitializeComponent();
            VkBools = new Switches();
            vkDatas = new VkDatas();
            playlist = new Playlist(new OwnAudios());
            if (File.Exists("auth.dat"))
            {
                Token = File.ReadAllText("auth.dat");
                GetAuth();
            }
            else
            {
                AuthForm f = new AuthForm
                {
                    Owner = this
                };
                f.ShowDialog();
            }
            player = new WindowsMediaPlayer();
            duration_timer.Stop();
            vkDatas.Audio = api.Audio.Get(new AudioGetParams { Count = api.Audio.GetCount(vkDatas.user_id) });
            playlist.SetAudioInfo(this);
            LoadText();
            play_pause_btn.Image = Resource1.play;
            artist_name.Font = Roboto_thin;
            title_name.Font = Roboto_medium;
            AudioList.Font = Roboto_thin_10;
            IdSongs_box.Font = Roboto_thin_10;
            searchAudio_box.Font = Roboto_thin_10;

            if (File.Exists("user_color.dat"))
            {
                byte darkTheme = 20;
                string[] vs = File.ReadAllText("user_color.dat").Split(' ');
                MainColor = Color.FromArgb(255, byte.Parse(vs[0]), byte.Parse(vs[1]), byte.Parse(vs[2]));
                addColor = Color.FromArgb(255, byte.Parse(vs[3]), byte.Parse(vs[4]), byte.Parse(vs[5]));
                if (byte.Parse(vs[0]) == darkTheme)
                {
                    VkBools.isBlack = true;
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
            else
            {
                MainColor = Color.FromArgb(255, 63, 81, 181);
                addColor = Color.FromArgb(255, 48, 63, 159);
            }
            SetColors(MainColor, addColor);
            Own.BackColor = addColor;
            BackColor = MainColor;
            AudioList.ContextMenuStrip = DeleteAudioMenu;
            KeyPreview = true;
            VkBools.isPlay = false;
            if (VkBools.isBlack)
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
                Roboto_medium = new Font(font.Families[1], 12);
                Roboto_thin = new Font(font.Families[0], 12);
                Roboto_thin_10 = new Font(font.Families[0], 11);
            }
            catch { }
        }

        private void AuthToken()
        {
            api.Authorize(new ApiAuthParams
            {
                AccessToken = Token,
                Settings = Settings.Offline
            });
            vkDatas.user_id = long.Parse(File.ReadAllText("user_id.dat"));
        }

        private void Auth2Fact(string login, string password)
        {
            api.Authorize(new ApiAuthParams
            {
                Login = login,
                Password = password,
                Settings = Settings.Offline,
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
            vkDatas.user_id = api.UserId.GetHashCode();
            File.WriteAllText("user_id.dat", vkDatas.user_id.ToString());
            File.WriteAllText("auth.dat", api.Token);
            Show();
        }

        private void AuthLogPass(string login, string password)
        {
            api.Authorize(new ApiAuthParams
            {
                Login = login,
                Password = password,
                Settings = Settings.Offline
            });
            vkDatas.user_id = api.UserId.GetHashCode();
            File.WriteAllText("user_id.dat", vkDatas.user_id.ToString());
            File.WriteAllText("auth.dat", api.Token);
            Show();
        }

        public void GetAuth(string login = null, string password = null)
        {
            
            vkDatas.service = new ServiceCollection();
            vkDatas.service.AddAudioBypass();
            api = new VkApi(vkDatas.service);
            if (Token != null)
            {
                AuthToken();
            }
            else
            {
                try
                {
                    Auth2Fact(login, password);
                    if (!api.IsAuthorized)
                        AuthLogPass(login, password);                        
                }
                catch
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK);
                }
                
            }
            rnd = new Random();
            isAuth = true;
        }

        private void play_pause()
        {
            if (!VkBools.isPlay)
            {
                player.controls.play();
                if (!VkBools.isBlack)
                    play_pause_btn.Image = Resource1.pause;
                else
                    play_pause_btn.Image = Resource1.pause_white;
                VkBools.isPlay = true;
            }
            else
            {
                player.controls.pause();
                if (!VkBools.isBlack)
                    play_pause_btn.Image = Resource1.play;
                else
                    play_pause_btn.Image = Resource1.play_white;
                VkBools.isPlay = false;
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
            playlist.PrevSong(this);
        }
        
        

        private void next_btn_Click(object sender, EventArgs e)
        {
            playlist.NextSong(this);
        }
        private void duration_timer_Tick(object sender, EventArgs e)
        {
            AllTimeDur.Text = player.currentMedia.durationString;
            duration_bar.Maximum = (int)player.currentMedia.duration;
            duration_bar.Value = (int)player.controls.currentPosition;
            currentTimeDur.Text = player.controls.currentPositionString;
        }

        private void duration_bar_Scroll(object sender, EventArgs e)
        {
            duration_bar.Maximum = (int)player.currentMedia.duration;
            player.controls.currentPosition = duration_bar.Value;
            currentTimeDur.Text = player.controls.currentPositionString;
        }
        private void timerForRefresh_Tick(object sender, EventArgs e)
        {
            if (Token != null && artist_name.Text == "artist" && title_name.Text == "title")
            {
                playlist.SetAudioInfo(this);
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

        private void NextSongTimer_Tick(object sender, EventArgs e)
        {
            if (player.status == "Остановлено")
            {
                if (!VkBools.repeat)
                    playlist.NextSong(this);
                player.controls.play();
            }
        }

        private void repeat_radio_Click(object sender, EventArgs e)
        {
            if (VkBools.repeat == false)
            {
                VkBools.repeat = true;
                repeat_radio.BackColor = addColor;
            }
            else
            {
                VkBools.repeat = false;
                repeat_radio.BackColor = MainColor;
            }
        }

        private void random_radio_Click(object sender, EventArgs e)
        {
            if (VkBools.random == false)
            {
                VkBools.random = true;
                random_radio.BackColor = addColor;
            }
            else
            {
                VkBools.random = false;
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
                    if (volume.Value + 1 <= volume.Maximum)
                    {
                        player.settings.volume += 1;
                        volume.Value += 1;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (volume.Value - 1 >= volume.Minimum)
                    {
                        player.settings.volume -= 1;
                        volume.Value -= 1;
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    playlist.PrevSong(this);
                }
                else if (e.KeyCode == Keys.Right)
                {
                    playlist.NextSong(this);
                }
                else if (e.KeyCode == Keys.M)
                {
                    SetMute_Unmute();
                }
                else if (e.KeyCode == Keys.O)
                {
                    SetState("own");
                }
                else if (e.KeyCode == Keys.H)
                {
                    SetState("hot");
                }
                else if (e.KeyCode == Keys.R)
                {
                    SetRecom();
                }
                else if (e.KeyCode == Keys.L)
                {
                    Hide_Unhide();
                }
            }
        }

        private void SetMute_Unmute()
        {
            if (VkBools.mute)
            {
                player.settings.mute = false;
                VkBools.mute = false;
                if (!VkBools.isBlack)
                    mute_unmute.Image = Resource1.unmute;
                else
                    mute_unmute.Image = Resource1.unmute_white;
            }
            else
            {
                player.settings.mute = true;
                VkBools.mute = true;
                if (!VkBools.isBlack)
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
            SetBackColorForLists();
            if (VkBools.isBlack)
            {
                if (VkBools.isPlay)
                    play_pause_btn.Image = Resource1.pause_white;
                else
                    play_pause_btn.Image = Resource1.play_white;
                next_btn.Image = Resource1.next_white;
                back_btn.Image = Resource1.prev_white;
                if (VkBools.mute)
                    mute_unmute.Image = Resource1.mute_white;
                else
                    mute_unmute.Image = Resource1.unmute_white;
                repeat_radio.Image = Resource1.repeat_white;
                random_radio.Image = Resource1.random_white;
                List.Image = Resource1.list_white;
                Hot.Image = Resource1.hot_white;
                recom.Image = Resource1.recom_white;
                Own.Image = Resource1.person_white;
                currentTimeDur.ForeColor = Color.White;
                AllTimeDur.ForeColor = Color.White;
            }

            if (!black && VkBools.isBlack)
            {
                VkBools.isBlack = false;

                if (VkBools.isPlay)
                    play_pause_btn.Image = Resource1.pause;
                else
                    play_pause_btn.Image = Resource1.play;
                next_btn.Image = Resource1.next;
                back_btn.Image = Resource1.prev;
                if (VkBools.mute)
                    mute_unmute.Image = Resource1.mute;
                else
                    mute_unmute.Image = Resource1.unmute;
                repeat_radio.Image = Resource1.repeat;
                random_radio.Image = Resource1.random;
                List.Image = Resource1.list;
                Hot.Image = Resource1.hot;
                recom.Image = Resource1.recom;
                Own.Image = Resource1.person;
                currentTimeDur.ForeColor = Color.Black;
                AllTimeDur.ForeColor = Color.Black;
            }

            this.BackColor = mainColor;
            this.MainColor = mainColor;
            this.addColor = addColor;
            SetBackColorForLists();
            AudioList.BackColor = addColor;
            searchAudio_box.BackColor = addColor;
            IdSongs_box.BackColor = addColor;
            if (VkBools.repeat)
            {
                repeat_radio.BackColor = addColor;
            }
            else
            {
                repeat_radio.BackColor = mainColor;
            }
            if (VkBools.random)
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
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor = 
                searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 171, 71, 188);
            Color add = Color.FromArgb(255, 123, 31, 162);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void deepPurpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 103, 58, 183);
            Color add = Color.FromArgb(255, 69, 39, 160);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void indigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 63, 81, 181);
            Color add = Color.FromArgb(255, 40, 53, 147);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 33, 150, 243);
            Color add = Color.FromArgb(255, 21, 101, 192);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void cyanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 198, 218);
            Color add = Color.FromArgb(255, 0, 151, 167);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void tealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 38, 166, 154);
            Color add = Color.FromArgb(255, 0, 121, 107);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 76, 175, 80);
            Color add = Color.FromArgb(255, 46, 125, 50);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void limeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 205, 220, 57);
            Color add = Color.FromArgb(255, 175, 180, 43);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 238, 88);
            Color add = Color.FromArgb(255, 253, 216, 53);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor 
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void amberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 202, 40);
            Color add = Color.FromArgb(255, 255, 179, 0);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor 
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 152, 0);
            Color add = Color.FromArgb(255, 245, 124, 0);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor 
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.Black;
            SetColors(main, add, false);
        }
        private void deepOrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 255, 87, 34);
            Color add = Color.FromArgb(255, 216, 67, 21);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor 
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void brownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 121, 85, 72);
            Color add = Color.FromArgb(255, 93, 64, 55);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor 
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void blueGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color main = Color.FromArgb(255, 120, 144, 156);
            Color add = Color.FromArgb(255, 69, 90, 100);
            artist_name.ForeColor = title_name.ForeColor = AudioList.ForeColor
                = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            SetColors(main, add, false);
        }
        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VkBools.isBlack = true;
            artist_name.ForeColor = title_name.ForeColor
                = AudioList.ForeColor = searchAudio_box.ForeColor = IdSongs_box.ForeColor = Color.White;
            Color main = Color.FromArgb(255, 20, 20, 20);
            Color add = Color.FromArgb(255, 50, 50, 50);
            SetColors(main, add);
        }

        private void SetBackColorForLists()
        {
            if (VkBools.IsOwn)
            {
                Hot.BackColor = MainColor;
                recom.BackColor = MainColor;
                Own.BackColor = addColor;
            }
            else if (VkBools.IsHot)
            {
                Own.BackColor = MainColor;
                recom.BackColor = MainColor;
                Hot.BackColor = addColor;
            }
            else if (VkBools.IsRecommend)
            {
                Own.BackColor = MainColor;
                Hot.BackColor = MainColor;
                recom.BackColor = addColor;
            }
            else
            {
                Own.BackColor = MainColor;
                Hot.BackColor = MainColor;
                recom.BackColor = MainColor;
            }
        }

        public void AddAudioToList(VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> audios)
        {            
            AudioList.Items.Clear();
            foreach (var audio in audios)
                AudioList.Items.Add($"{audio.Artist} - {audio.Title}");
        }

        private void SearchAudio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SetState("search");
                AudioList.ContextMenuStrip = AddAudioMenu;
            }
            else
            {                
            if (searchAudio_box.Text == "Поиск")
                {
                    searchAudio_box.Text = "";
                    searchAudio_box.ForeColor = Color.White;
                }
            }
        }


        private void AudioList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                playlist.SetAudioInfo(this);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete("auth.dat");
            System.IO.File.Delete("user_id.dat");
            System.IO.File.Delete("user_color.dat");
            System.Windows.Forms.Application.Restart();
            Close();
        }

        private void Hide_Unhide()
        {
            if (VkBools.IsMaximize)
            {
                //Width = 365;
                Height = 167;
                VkBools.IsMaximize = false;
            }
            else
            {
                //Width = 601;
                Height = 405;
                VkBools.IsMaximize = true;
            }
            play_pause_btn.Focus();
        }
        private void List_Click(object sender, EventArgs e)
        {
            Hide_Unhide();
        }

        private void SwitchStatesOff()
        {
            VkBools.IsHot = false;
            VkBools.IsOwn = false;
            VkBools.IsRecommend = false;
            VkBools.IsSearch = false;
        }        

        private void Own_Click(object sender, EventArgs e)
        {
            vkDatas.Audio = api.Audio.Get(new AudioGetParams { Count = api.Audio.GetCount(vkDatas.user_id) });
            SetState("own");
            AudioList.ContextMenuStrip = DeleteAudioMenu;
        }

        private void Hot_Click(object sender, EventArgs e)
        {
            SetState("hot");
            AudioList.ContextMenuStrip = AddAudioMenu;
        }

        private void SetState(string state)
        {            
            state = state.ToUpper();
            switch (state)
            {
                case "OWN":
                    SwitchStatesOff();
                    AudioList.Items.Clear();
                    VkBools.IsOwn = true;
                    playlist = new Playlist(new OwnAudios());
                    SetBackColorForLists();
                    AddAudioToList(vkDatas.Audio);
                    AudioList.SelectedIndex = vkDatas._offset;
                    break;
                case "HOT":
                    SwitchStatesOff();
                    AudioList.Items.Clear();
                    VkBools.IsHot = true;
                    SetBackColorForLists();
                    playlist = new Playlist(new HotAudio());
                    vkDatas.HotAudios = api.Audio.GetPopular(false, null, 35, null);
                    foreach (var audio in vkDatas.HotAudios)
                        AudioList.Items.Add($"{audio.Artist} - {audio.Title}");
                    break;
                case "SEARCH":
                    SwitchStatesOff();
                    AudioList.Items.Clear();
                    VkBools.IsSearch = true;
                    SetBackColorForLists();
                    playlist = new Playlist(new SearchAudios());
                    AudioList.Items.Clear();
                    try
                    {
                        vkDatas.SearchAudios = api.Audio.Search(new AudioSearchParams
                        {
                            Query = searchAudio_box.Text,
                            Autocomplete = true,
                            SearchOwn = true,
                            Count = 20,
                            PerformerOnly = false
                        });
                        AddAudioToList(vkDatas.SearchAudios);
                    }
                    catch { }
                    break;
                case "RECOM":
                    SwitchStatesOff();
                    AudioList.Items.Clear();
                    VkBools.IsRecommend = true;
                    SetBackColorForLists();
                    playlist = new Playlist(new RecommendedAudio());
                    vkDatas.RecommendedAudio = api.Audio.GetRecommendations(null, null, 50, null, true);
                    AddAudioToList(vkDatas.RecommendedAudio);
                    break;
                case "ID":
                    try
                    {
                        vkDatas.IdAudios = api.Audio.Get
                            (new AudioGetParams { OwnerId = long.Parse(IdSongs_box.Text), Count = api.Audio.GetCount(long.Parse(IdSongs_box.Text)) });
                        SwitchStatesOff();
                        AudioList.Items.Clear();
                        VkBools.isId = true;
                        SetBackColorForLists();
                        playlist = new Playlist(new IdAudios());
                        AddAudioToList(vkDatas.IdAudios);
                    }
                    catch
                    {
                        IdSongs_box.Text = "id";
                        IdSongs_box.ForeColor = Color.LightGray;
                        MessageBox.Show(this, "У пользователя закрыты аудиозаписи!", "Ошибка", MessageBoxButtons.OK);
                    }
                    break;

            }
        }

        private void SetRecom()
        {
            SetBackColorForLists();
            playlist = new Playlist(new RecommendedAudio());
            vkDatas.RecommendedAudio = api.Audio.GetRecommendations(null, null, 50, null, true);
            AddAudioToList(vkDatas.RecommendedAudio);
            playlist.NextSong(this);
        }
        private void recom_Click(object sender, EventArgs e)
        {
            SetState("recom");
            AudioList.ContextMenuStrip = AddAudioMenu;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                playlist.AudioMenuClick(this);
            }
            catch { }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playlist.AudioMenuClick(this);
            vkDatas.Audio = api.Audio.Get(new AudioGetParams { Count = api.Audio.GetCount(vkDatas.user_id) });
            AddAudioToList(vkDatas.Audio);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(Own, "Свои аудиозаписи");
            t.SetToolTip(Hot, "Популярное");
            t.SetToolTip(recom, "Рекомендации");
            t.SetToolTip(searchAudio_box, "Поиск");
        }

        private void searchAudio_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchAudio_box.Text == "")
            {
                searchAudio_box.Text = "Поиск";
                searchAudio_box.ForeColor = Color.LightGray;
            }
        }

        private void IdSongs_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SetState("id");
                AudioList.ContextMenuStrip = AddAudioMenu;
            }
            else
            {
                if (IdSongs_box.Text == "Id")
                {
                    IdSongs_box.Text = "";
                    IdSongs_box.ForeColor = Color.White;
                }
            }
        }

        private void IdSongs_box_KeyUp(object sender, KeyEventArgs e)
        {
            if (IdSongs_box.Text == "")
            {
                IdSongs_box.Text = "Id";
                IdSongs_box.ForeColor = Color.LightGray;
            }
        }
    }
}