namespace VkPlayer
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.artist_name = new System.Windows.Forms.Label();
            this.title_name = new System.Windows.Forms.Label();
            this.volume = new System.Windows.Forms.TrackBar();
            this.duration_bar = new System.Windows.Forms.TrackBar();
            this.duration_timer = new System.Windows.Forms.Timer(this.components);
            this.timerForRefresh = new System.Windows.Forms.Timer(this.components);
            this.NextSongTimer = new System.Windows.Forms.Timer(this.components);
            this.colorLime_btn = new System.Windows.Forms.Label();
            this.colorCyan_btn = new System.Windows.Forms.Label();
            this.colorDeepPurple_btn = new System.Windows.Forms.Label();
            this.colorGreen_btn = new System.Windows.Forms.Label();
            this.colorTeal_btn = new System.Windows.Forms.Label();
            this.colorBlue_btn = new System.Windows.Forms.Label();
            this.colorIndigo_btn = new System.Windows.Forms.Label();
            this.colorPurple_btn = new System.Windows.Forms.Label();
            this.ColorRed_btn = new System.Windows.Forms.Label();
            this.SelectColor_btn = new System.Windows.Forms.Label();
            this.mute_unmute = new System.Windows.Forms.Label();
            this.random_radio = new System.Windows.Forms.Label();
            this.repeat_radio = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Label();
            this.next_btn = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Label();
            this.play_pause_btn = new System.Windows.Forms.Label();
            this.colorYellow_btn = new System.Windows.Forms.Label();
            this.colorAmber_btn = new System.Windows.Forms.Label();
            this.colorOrange_btn = new System.Windows.Forms.Label();
            this.colorDeepOrange_btn = new System.Windows.Forms.Label();
            this.colorBrown_btn = new System.Windows.Forms.Label();
            this.colorBlueGrey_btn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // artist_name
            // 
            this.artist_name.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.artist_name, "artist_name");
            this.artist_name.ForeColor = System.Drawing.Color.White;
            this.artist_name.Name = "artist_name";
            this.artist_name.Click += new System.EventHandler(this.artist_name_Click);
            // 
            // title_name
            // 
            this.title_name.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.title_name, "title_name");
            this.title_name.ForeColor = System.Drawing.Color.White;
            this.title_name.Name = "title_name";
            // 
            // volume
            // 
            resources.ApplyResources(this.volume, "volume");
            this.volume.Maximum = 100;
            this.volume.Name = "volume";
            this.volume.TabStop = false;
            this.volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volume.Value = 50;
            this.volume.Scroll += new System.EventHandler(this.volume_Scroll);
            // 
            // duration_bar
            // 
            resources.ApplyResources(this.duration_bar, "duration_bar");
            this.duration_bar.Maximum = 500;
            this.duration_bar.Name = "duration_bar";
            this.duration_bar.TabStop = false;
            this.duration_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.duration_bar.Scroll += new System.EventHandler(this.duration_bar_Scroll);
            // 
            // duration_timer
            // 
            this.duration_timer.Interval = 1000;
            this.duration_timer.Tick += new System.EventHandler(this.duration_timer_Tick);
            // 
            // timerForRefresh
            // 
            this.timerForRefresh.Enabled = true;
            this.timerForRefresh.Interval = 10;
            this.timerForRefresh.Tick += new System.EventHandler(this.timerForRefresh_Tick);
            // 
            // NextSongTimer
            // 
            this.NextSongTimer.Interval = 1000;
            this.NextSongTimer.Tick += new System.EventHandler(this.NextSongTimer_Tick);
            // 
            // colorLime_btn
            // 
            this.colorLime_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorLime_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorLime_btn.Image = global::VkPlayer.Resource1.colorLime;
            resources.ApplyResources(this.colorLime_btn, "colorLime_btn");
            this.colorLime_btn.Name = "colorLime_btn";
            this.colorLime_btn.Click += new System.EventHandler(this.colorLime_btn_Click);
            // 
            // colorCyan_btn
            // 
            this.colorCyan_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorCyan_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorCyan_btn.Image = global::VkPlayer.Resource1.colorCyan;
            resources.ApplyResources(this.colorCyan_btn, "colorCyan_btn");
            this.colorCyan_btn.Name = "colorCyan_btn";
            this.colorCyan_btn.Click += new System.EventHandler(this.colorCyan_btn_Click);
            // 
            // colorDeepPurple_btn
            // 
            this.colorDeepPurple_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorDeepPurple_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorDeepPurple_btn.Image = global::VkPlayer.Resource1.rolorDeepPurple;
            resources.ApplyResources(this.colorDeepPurple_btn, "colorDeepPurple_btn");
            this.colorDeepPurple_btn.Name = "colorDeepPurple_btn";
            this.colorDeepPurple_btn.Click += new System.EventHandler(this.colorDeepPurple_btn_Click);
            // 
            // colorGreen_btn
            // 
            this.colorGreen_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorGreen_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorGreen_btn.Image = global::VkPlayer.Resource1.colorGreen;
            resources.ApplyResources(this.colorGreen_btn, "colorGreen_btn");
            this.colorGreen_btn.Name = "colorGreen_btn";
            this.colorGreen_btn.Click += new System.EventHandler(this.colorGreen_btn_Click);
            // 
            // colorTeal_btn
            // 
            this.colorTeal_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorTeal_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorTeal_btn.Image = global::VkPlayer.Resource1.colorTeal;
            resources.ApplyResources(this.colorTeal_btn, "colorTeal_btn");
            this.colorTeal_btn.Name = "colorTeal_btn";
            this.colorTeal_btn.Click += new System.EventHandler(this.colorTeal_btn_Click);
            // 
            // colorBlue_btn
            // 
            this.colorBlue_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorBlue_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorBlue_btn.Image = global::VkPlayer.Resource1.colorBlue;
            resources.ApplyResources(this.colorBlue_btn, "colorBlue_btn");
            this.colorBlue_btn.Name = "colorBlue_btn";
            this.colorBlue_btn.Click += new System.EventHandler(this.colorBlue_btn_Click);
            // 
            // colorIndigo_btn
            // 
            this.colorIndigo_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorIndigo_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorIndigo_btn.Image = global::VkPlayer.Resource1.rolorIndigo;
            resources.ApplyResources(this.colorIndigo_btn, "colorIndigo_btn");
            this.colorIndigo_btn.Name = "colorIndigo_btn";
            this.colorIndigo_btn.Click += new System.EventHandler(this.colorIndigo_btn_Click);
            // 
            // colorPurple_btn
            // 
            this.colorPurple_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorPurple_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPurple_btn.Image = global::VkPlayer.Resource1.rolorPurple;
            resources.ApplyResources(this.colorPurple_btn, "colorPurple_btn");
            this.colorPurple_btn.Name = "colorPurple_btn";
            this.colorPurple_btn.Click += new System.EventHandler(this.colorPurple_btn_Click);
            // 
            // ColorRed_btn
            // 
            this.ColorRed_btn.BackColor = System.Drawing.Color.Transparent;
            this.ColorRed_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColorRed_btn.Image = global::VkPlayer.Resource1.rolorRed;
            resources.ApplyResources(this.ColorRed_btn, "ColorRed_btn");
            this.ColorRed_btn.Name = "ColorRed_btn";
            this.ColorRed_btn.Click += new System.EventHandler(this.ColorRed_btn_Click);
            // 
            // SelectColor_btn
            // 
            this.SelectColor_btn.BackColor = System.Drawing.Color.Transparent;
            this.SelectColor_btn.Image = global::VkPlayer.Resource1.colorCircle;
            resources.ApplyResources(this.SelectColor_btn, "SelectColor_btn");
            this.SelectColor_btn.Name = "SelectColor_btn";
            this.SelectColor_btn.Click += new System.EventHandler(this.SelectColor_btn_Click);
            // 
            // mute_unmute
            // 
            this.mute_unmute.BackColor = System.Drawing.Color.Transparent;
            this.mute_unmute.Image = global::VkPlayer.Resource1.unmute;
            resources.ApplyResources(this.mute_unmute, "mute_unmute");
            this.mute_unmute.Name = "mute_unmute";
            this.mute_unmute.Click += new System.EventHandler(this.mute_unmute_Click);
            // 
            // random_radio
            // 
            this.random_radio.BackColor = System.Drawing.Color.Transparent;
            this.random_radio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.random_radio.Image = global::VkPlayer.Resource1.random;
            resources.ApplyResources(this.random_radio, "random_radio");
            this.random_radio.Name = "random_radio";
            this.random_radio.Click += new System.EventHandler(this.random_radio_Click);
            // 
            // repeat_radio
            // 
            this.repeat_radio.BackColor = System.Drawing.Color.Transparent;
            this.repeat_radio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repeat_radio.Image = global::VkPlayer.Resource1.repeat;
            resources.ApplyResources(this.repeat_radio, "repeat_radio");
            this.repeat_radio.Name = "repeat_radio";
            this.repeat_radio.Click += new System.EventHandler(this.repeat_radio_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Transparent;
            this.Logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logout.Image = global::VkPlayer.Resource1.door;
            resources.ApplyResources(this.Logout, "Logout");
            this.Logout.Name = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // next_btn
            // 
            this.next_btn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.next_btn, "next_btn");
            this.next_btn.Image = global::VkPlayer.Resource1.next;
            this.next_btn.Name = "next_btn";
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.back_btn, "back_btn");
            this.back_btn.Name = "back_btn";
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // play_pause_btn
            // 
            this.play_pause_btn.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.play_pause_btn, "play_pause_btn");
            this.play_pause_btn.Name = "play_pause_btn";
            this.play_pause_btn.Click += new System.EventHandler(this.play_pause_btn_Click);
            // 
            // colorYellow_btn
            // 
            this.colorYellow_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorYellow_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorYellow_btn.Image = global::VkPlayer.Resource1.colorYellow;
            resources.ApplyResources(this.colorYellow_btn, "colorYellow_btn");
            this.colorYellow_btn.Name = "colorYellow_btn";
            this.colorYellow_btn.Click += new System.EventHandler(this.colorYellow_btn_Click);
            // 
            // colorAmber_btn
            // 
            this.colorAmber_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorAmber_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorAmber_btn.Image = global::VkPlayer.Resource1.colorAmber;
            resources.ApplyResources(this.colorAmber_btn, "colorAmber_btn");
            this.colorAmber_btn.Name = "colorAmber_btn";
            this.colorAmber_btn.Click += new System.EventHandler(this.colorAmber_btn_Click);
            // 
            // colorOrange_btn
            // 
            this.colorOrange_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorOrange_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorOrange_btn.Image = global::VkPlayer.Resource1.coloOrange;
            resources.ApplyResources(this.colorOrange_btn, "colorOrange_btn");
            this.colorOrange_btn.Name = "colorOrange_btn";
            this.colorOrange_btn.Click += new System.EventHandler(this.colorOrange_btn_Click);
            // 
            // colorDeepOrange_btn
            // 
            this.colorDeepOrange_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorDeepOrange_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorDeepOrange_btn.Image = global::VkPlayer.Resource1.colorDeepOrange;
            resources.ApplyResources(this.colorDeepOrange_btn, "colorDeepOrange_btn");
            this.colorDeepOrange_btn.Name = "colorDeepOrange_btn";
            this.colorDeepOrange_btn.Click += new System.EventHandler(this.colorDeepOrange_btn_Click);
            // 
            // colorBrown_btn
            // 
            this.colorBrown_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorBrown_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorBrown_btn.Image = global::VkPlayer.Resource1.colorBrown;
            resources.ApplyResources(this.colorBrown_btn, "colorBrown_btn");
            this.colorBrown_btn.Name = "colorBrown_btn";
            this.colorBrown_btn.Click += new System.EventHandler(this.colorBrown_btn_Click);
            // 
            // colorBlueGrey_btn
            // 
            this.colorBlueGrey_btn.BackColor = System.Drawing.Color.Transparent;
            this.colorBlueGrey_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorBlueGrey_btn.Image = global::VkPlayer.Resource1.coloBlueGrey;
            resources.ApplyResources(this.colorBlueGrey_btn, "colorBlueGrey_btn");
            this.colorBlueGrey_btn.Name = "colorBlueGrey_btn";
            this.colorBlueGrey_btn.Click += new System.EventHandler(this.colorBlueGrey_btn_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.ColorRed_btn);
            this.Controls.Add(this.colorIndigo_btn);
            this.Controls.Add(this.colorTeal_btn);
            this.Controls.Add(this.colorYellow_btn);
            this.Controls.Add(this.colorDeepOrange_btn);
            this.Controls.Add(this.title_name);
            this.Controls.Add(this.colorBlueGrey_btn);
            this.Controls.Add(this.colorOrange_btn);
            this.Controls.Add(this.colorLime_btn);
            this.Controls.Add(this.colorCyan_btn);
            this.Controls.Add(this.colorDeepPurple_btn);
            this.Controls.Add(this.colorBrown_btn);
            this.Controls.Add(this.colorAmber_btn);
            this.Controls.Add(this.colorGreen_btn);
            this.Controls.Add(this.colorBlue_btn);
            this.Controls.Add(this.colorPurple_btn);
            this.Controls.Add(this.SelectColor_btn);
            this.Controls.Add(this.mute_unmute);
            this.Controls.Add(this.random_radio);
            this.Controls.Add(this.repeat_radio);
            this.Controls.Add(this.duration_bar);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.artist_name);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.play_pause_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration_bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label play_pause_btn;
        private System.Windows.Forms.Label back_btn;
        private System.Windows.Forms.Label next_btn;
        private System.Windows.Forms.Label artist_name;
        private System.Windows.Forms.Label title_name;
        private System.Windows.Forms.TrackBar volume;
        private System.Windows.Forms.TrackBar duration_bar;
        private System.Windows.Forms.Timer duration_timer;
        private System.Windows.Forms.Timer timerForRefresh;
        private System.Windows.Forms.Label Logout;
        private System.Windows.Forms.Timer NextSongTimer;
        private System.Windows.Forms.Label repeat_radio;
        private System.Windows.Forms.Label random_radio;
        private System.Windows.Forms.Label mute_unmute;
        private System.Windows.Forms.Label SelectColor_btn;
        private System.Windows.Forms.Label ColorRed_btn;
        private System.Windows.Forms.Label colorPurple_btn;
        private System.Windows.Forms.Label colorDeepPurple_btn;
        private System.Windows.Forms.Label colorIndigo_btn;
        private System.Windows.Forms.Label colorBlue_btn;
        private System.Windows.Forms.Label colorCyan_btn;
        private System.Windows.Forms.Label colorTeal_btn;
        private System.Windows.Forms.Label colorGreen_btn;
        private System.Windows.Forms.Label colorLime_btn;
        private System.Windows.Forms.Label colorYellow_btn;
        private System.Windows.Forms.Label colorAmber_btn;
        private System.Windows.Forms.Label colorOrange_btn;
        private System.Windows.Forms.Label colorDeepOrange_btn;
        private System.Windows.Forms.Label colorBrown_btn;
        private System.Windows.Forms.Label colorBlueGrey_btn;
    }
}

