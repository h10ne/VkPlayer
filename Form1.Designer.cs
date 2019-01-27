﻿namespace VkPlayer
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
            this.mute_unmute = new System.Windows.Forms.Label();
            this.random_radio = new System.Windows.Forms.Label();
            this.repeat_radio = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Label();
            this.next_btn = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Label();
            this.play_pause_btn = new System.Windows.Forms.Label();
            this.currentTimeDur = new System.Windows.Forms.Label();
            this.AllTimeDur = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deepPurpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cyanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deepOrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duration_bar)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // artist_name
            // 
            this.artist_name.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.artist_name, "artist_name");
            this.artist_name.ForeColor = System.Drawing.Color.White;
            this.artist_name.Name = "artist_name";
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
            this.volume.LargeChange = 0;
            this.volume.Maximum = 100;
            this.volume.Name = "volume";
            this.volume.SmallChange = 0;
            this.volume.TabStop = false;
            this.volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volume.Value = 50;
            this.volume.Scroll += new System.EventHandler(this.volume_Scroll);
            // 
            // duration_bar
            // 
            resources.ApplyResources(this.duration_bar, "duration_bar");
            this.duration_bar.LargeChange = 0;
            this.duration_bar.Maximum = 500;
            this.duration_bar.Name = "duration_bar";
            this.duration_bar.SmallChange = 0;
            this.duration_bar.TabStop = false;
            this.duration_bar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.duration_bar.Scroll += new System.EventHandler(this.duration_bar_Scroll);
            // 
            // duration_timer
            // 
            this.duration_timer.Interval = 500;
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
            this.next_btn.Image = global::VkPlayer.Resource1.next;
            resources.ApplyResources(this.next_btn, "next_btn");
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
            // currentTimeDur
            // 
            resources.ApplyResources(this.currentTimeDur, "currentTimeDur");
            this.currentTimeDur.Name = "currentTimeDur";
            // 
            // AllTimeDur
            // 
            resources.ApplyResources(this.AllTimeDur, "AllTimeDur");
            this.AllTimeDur.Name = "AllTimeDur";
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseColorToolStripMenuItem});
            this.Menu.Name = "Menu";
            resources.ApplyResources(this.Menu, "Menu");
            // 
            // chooseColorToolStripMenuItem
            // 
            this.chooseColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.purpleToolStripMenuItem,
            this.deepPurpleToolStripMenuItem,
            this.indigoToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.cyanToolStripMenuItem,
            this.tealToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.limeToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.amberToolStripMenuItem,
            this.orangeToolStripMenuItem,
            this.deepOrangeToolStripMenuItem,
            this.brownToolStripMenuItem,
            this.blueGrayToolStripMenuItem});
            resources.ApplyResources(this.chooseColorToolStripMenuItem, "chooseColorToolStripMenuItem");
            this.chooseColorToolStripMenuItem.Image = global::VkPlayer.Resource1.colorCircle;
            this.chooseColorToolStripMenuItem.Name = "chooseColorToolStripMenuItem";
            // 
            // redToolStripMenuItem
            // 
            resources.ApplyResources(this.redToolStripMenuItem, "redToolStripMenuItem");
            this.redToolStripMenuItem.Image = global::VkPlayer.Resource1.rolorRed;
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
            // 
            // purpleToolStripMenuItem
            // 
            this.purpleToolStripMenuItem.Image = global::VkPlayer.Resource1.rolorPurple;
            this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            resources.ApplyResources(this.purpleToolStripMenuItem, "purpleToolStripMenuItem");
            this.purpleToolStripMenuItem.Click += new System.EventHandler(this.pinkToolStripMenuItem_Click);
            // 
            // deepPurpleToolStripMenuItem
            // 
            this.deepPurpleToolStripMenuItem.Image = global::VkPlayer.Resource1.rolorDeepPurple;
            this.deepPurpleToolStripMenuItem.Name = "deepPurpleToolStripMenuItem";
            resources.ApplyResources(this.deepPurpleToolStripMenuItem, "deepPurpleToolStripMenuItem");
            this.deepPurpleToolStripMenuItem.Click += new System.EventHandler(this.deepPurpleToolStripMenuItem_Click);
            // 
            // indigoToolStripMenuItem
            // 
            this.indigoToolStripMenuItem.Image = global::VkPlayer.Resource1.rolorIndigo;
            this.indigoToolStripMenuItem.Name = "indigoToolStripMenuItem";
            resources.ApplyResources(this.indigoToolStripMenuItem, "indigoToolStripMenuItem");
            this.indigoToolStripMenuItem.Click += new System.EventHandler(this.indigoToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Image = global::VkPlayer.Resource1.colorBlue;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            resources.ApplyResources(this.blueToolStripMenuItem, "blueToolStripMenuItem");
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // cyanToolStripMenuItem
            // 
            this.cyanToolStripMenuItem.Image = global::VkPlayer.Resource1.colorCyan;
            this.cyanToolStripMenuItem.Name = "cyanToolStripMenuItem";
            resources.ApplyResources(this.cyanToolStripMenuItem, "cyanToolStripMenuItem");
            this.cyanToolStripMenuItem.Click += new System.EventHandler(this.cyanToolStripMenuItem_Click);
            // 
            // tealToolStripMenuItem
            // 
            this.tealToolStripMenuItem.Image = global::VkPlayer.Resource1.colorTeal;
            this.tealToolStripMenuItem.Name = "tealToolStripMenuItem";
            resources.ApplyResources(this.tealToolStripMenuItem, "tealToolStripMenuItem");
            this.tealToolStripMenuItem.Click += new System.EventHandler(this.tealToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Image = global::VkPlayer.Resource1.colorGreen;
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            resources.ApplyResources(this.greenToolStripMenuItem, "greenToolStripMenuItem");
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // limeToolStripMenuItem
            // 
            this.limeToolStripMenuItem.Image = global::VkPlayer.Resource1.colorLime;
            this.limeToolStripMenuItem.Name = "limeToolStripMenuItem";
            resources.ApplyResources(this.limeToolStripMenuItem, "limeToolStripMenuItem");
            this.limeToolStripMenuItem.Click += new System.EventHandler(this.limeToolStripMenuItem_Click);
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.Image = global::VkPlayer.Resource1.colorYellow;
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            resources.ApplyResources(this.yellowToolStripMenuItem, "yellowToolStripMenuItem");
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
            // 
            // amberToolStripMenuItem
            // 
            this.amberToolStripMenuItem.Image = global::VkPlayer.Resource1.colorAmber;
            this.amberToolStripMenuItem.Name = "amberToolStripMenuItem";
            resources.ApplyResources(this.amberToolStripMenuItem, "amberToolStripMenuItem");
            this.amberToolStripMenuItem.Click += new System.EventHandler(this.amberToolStripMenuItem_Click);
            // 
            // orangeToolStripMenuItem
            // 
            this.orangeToolStripMenuItem.Image = global::VkPlayer.Resource1.coloOrange;
            this.orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
            resources.ApplyResources(this.orangeToolStripMenuItem, "orangeToolStripMenuItem");
            this.orangeToolStripMenuItem.Click += new System.EventHandler(this.orangeToolStripMenuItem_Click);
            // 
            // deepOrangeToolStripMenuItem
            // 
            this.deepOrangeToolStripMenuItem.Image = global::VkPlayer.Resource1.colorDeepOrange;
            this.deepOrangeToolStripMenuItem.Name = "deepOrangeToolStripMenuItem";
            resources.ApplyResources(this.deepOrangeToolStripMenuItem, "deepOrangeToolStripMenuItem");
            this.deepOrangeToolStripMenuItem.Click += new System.EventHandler(this.deepOrangeToolStripMenuItem_Click);
            // 
            // brownToolStripMenuItem
            // 
            this.brownToolStripMenuItem.Image = global::VkPlayer.Resource1.colorBrown;
            this.brownToolStripMenuItem.Name = "brownToolStripMenuItem";
            resources.ApplyResources(this.brownToolStripMenuItem, "brownToolStripMenuItem");
            this.brownToolStripMenuItem.Click += new System.EventHandler(this.brownToolStripMenuItem_Click);
            // 
            // blueGrayToolStripMenuItem
            // 
            this.blueGrayToolStripMenuItem.Image = global::VkPlayer.Resource1.coloBlueGrey;
            this.blueGrayToolStripMenuItem.Name = "blueGrayToolStripMenuItem";
            resources.ApplyResources(this.blueGrayToolStripMenuItem, "blueGrayToolStripMenuItem");
            this.blueGrayToolStripMenuItem.Click += new System.EventHandler(this.blueGrayToolStripMenuItem_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.Controls.Add(this.AllTimeDur);
            this.Controls.Add(this.currentTimeDur);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.title_name);
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
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label currentTimeDur;
        private System.Windows.Forms.Label AllTimeDur;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem chooseColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deepPurpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cyanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deepOrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueGrayToolStripMenuItem;
    }
}

