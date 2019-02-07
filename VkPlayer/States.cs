using System;
using System.Threading;
using VkPlayer;

class Playlist
{
    public IState State { get; set; }
    public Playlist(IState ws)
    {
        State = ws;
    }
    public void NextSong(VkPlayer.Main main)
    {
        State.NextSong(main);
    }

    public void PrevSong(VkPlayer.Main main)
    {
        State.PrevSong(main);
    }

    public void SetAudioInfo(VkPlayer.Main main, bool isback = false)
    {
        State.SetAudioInfo(main);
    }
}

interface IState
{
    void NextSong(VkPlayer.Main main);
    void PrevSong(VkPlayer.Main main);
    void SetAudioInfo(VkPlayer.Main main, bool isback = false);
}

class OwnAudios:IState
{
    public void SetAudioInfo(VkPlayer.Main main, bool isback = false)
    {      
        try
        {
            if (main.vkDatas._offset == -1)
                throw new Exception();
            foreach (var audio in main.vkDatas.audio)
                if (audio.Artist + " - " + audio.Title == main.AudioList.SelectedItem.ToString())
                {
                    main.vkDatas._offset = main.AudioList.SelectedIndex;
                    bool th = false;
                    while (main.vkDatas.audio[main.vkDatas._offset].Url == null)
                    {
                        if (isback)
                            main.vkDatas._offset--;
                        else
                            main.vkDatas._offset++;
                        th = true;
                    }
                    if (th) throw new Exception("1");
                    main.player.URL = audio.Url.ToString();
                    main.artist_name.Text = audio.Artist;
                    main.title_name.Text = audio.Title;
                    main.player.controls.play();
                    break;
                }

        }
        catch
        {
            Thread.Sleep(270);
            if (main.vkDatas._offset == -1)
                main.vkDatas._offset++;
            main.player.settings.volume = main.volume.Value;
            main.player.URL = main.vkDatas.audio[main.vkDatas._offset].Url.ToString();
            main.artist_name.Text = main.vkDatas.audio[main.vkDatas._offset].Artist;
            main.title_name.Text = main.vkDatas.audio[main.vkDatas._offset].Title;
            main.duration_timer.Start();
            main.duration_bar.Value = 0;
            main.AddAudioToList(main.vkDatas.audio);
            main.AudioList.SelectedIndex = main.vkDatas._offset;
        }
        

        if (main.VkBools.isBlack)
            main.play_pause_btn.Image = Resource1.pause_white;
        else
            main.play_pause_btn.Image = Resource1.pause;
        main.VkBools.isPlay = true;
    }

    public void NextSong(VkPlayer.Main main)
    {
        if (main.VkBools.random)
        {
            Random rnds = new Random();
            int value = rnds.Next(0, int.Parse(main.api.Audio.GetCount(main.vkDatas.user_id).ToString())-1);
            main.AudioList.SelectedIndex = value;
            SetAudioInfo(main);
        }
        else
        {
            try
            {
                main.AudioList.SelectedIndex += 1;
                SetAudioInfo(main);
            }
            catch
            {
                main.AudioList.SelectedIndex = 0;
                SetAudioInfo(main);
            }
        }
    }

    public void PrevSong(VkPlayer.Main main)
    {
        try
        {

            main.AudioList.SelectedIndex -= 1;
            if (main.AudioList.SelectedIndex == -1)
                main.AudioList.SelectedIndex = int.Parse(main.api.Audio.GetCount(main.vkDatas.user_id).ToString()) - 1;
            SetAudioInfo(main, true);
        }
        catch
        {
            SetAudioInfo(main, true);
        }
    }
}

class SearchAudios:IState
{
    public void PrevSong(VkPlayer.Main main)
    {
        try
        {

            main.AudioList.SelectedIndex -= 1;
            SetAudioInfo(main);
        }
        catch
        {
            main.AudioList.SelectedIndex = 19;
            SetAudioInfo(main, true);
        }
    }

    public void NextSong(VkPlayer.Main main)
    {
        if (main.vkDatas.searchAudios!=null)
        {
            if (main.VkBools.random)
            {
                Random rnds = new Random();
                int value = rnds.Next(0, 19);
                main.AudioList.SelectedIndex = value;
                SetAudioInfo(main);
            }
            else
            {
                try
                {
                    main.AudioList.SelectedIndex += 1;
                    SetAudioInfo(main);
                }
                catch
                {
                    main.AudioList.SelectedIndex = 0;
                    SetAudioInfo(main);
                }
            }
        }        
    }
    public void SetAudioInfo(VkPlayer.Main main, bool isback = false)
    {
        foreach (var audio in main.vkDatas.searchAudios)
            if (audio.Artist + " - " + audio.Title == main.AudioList.SelectedItem.ToString())
            {
                main.player.URL = audio.Url.ToString();
                main.artist_name.Text = audio.Artist;
                main.title_name.Text = audio.Title;
                main.player.controls.play();
                break;
            }
        if (main.VkBools.isBlack)
            main.play_pause_btn.Image = Resource1.pause_white;
        else
            main.play_pause_btn.Image = Resource1.pause;
        main.VkBools.isPlay = true;
    }
}