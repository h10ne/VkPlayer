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
        while (main.vkDatas.audio[main.vkDatas._offset].Url == null)
        {
            if (isback)
                main.vkDatas._offset--;
            else
                main.vkDatas._offset++;
        }
        Thread.Sleep(270);
        main.player.settings.volume = main.volume.Value;
        main.player.URL = main.vkDatas.audio[main.vkDatas._offset].Url.ToString();
        main.artist_name.Text = main.vkDatas.audio[main.vkDatas._offset].Artist;
        main.title_name.Text = main.vkDatas.audio[main.vkDatas._offset].Title;
        main.duration_timer.Start();
        main.duration_bar.Value = 0;

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
            main.vkDatas._offset = main.rnd.Next(0, (int)main.api.Audio.GetCount(main.vkDatas.user_id));
        }
        if (main.api.Audio.GetCount(main.vkDatas.user_id) > main.vkDatas._offset)
        {
            main.vkDatas._offset++;
        }
        else        
        {
            main.vkDatas._offset = 0;
        }
        SetAudioInfo(main);
    }

    public void PrevSong(VkPlayer.Main main)
    {
        if (main.vkDatas._offset != 0)
        {
            main.vkDatas._offset--;
        }
        SetAudioInfo(main, true);
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
        if (main.VkBools.random)
        {
            Random rnds = new Random();
            int value = rnds.Next(0, 19);
            main.AudioList.SelectedIndex = value;
            try
            {
                SetAudioInfo(main);
            }
            catch
            {

            }
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
    public void SetAudioInfo(VkPlayer.Main main, bool isback = false)
    {
        main.CutAudio(main.AudioList.SelectedItem.ToString(), out string artist, out string title);

        foreach (var audio in main.vkDatas.searchAudios)
            if (audio.Artist == artist && audio.Title == title)
            {
                main.player.URL = audio.Url.ToString();
                main.artist_name.Text = artist;
                main.title_name.Text = title;
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