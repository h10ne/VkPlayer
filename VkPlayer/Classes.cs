using Microsoft.Extensions.DependencyInjection;

public class BoolClass
{
    public bool isPlay { get; set; } = false;
    public bool mute { get; set; } = false;
    public bool isBlack { get; set; } = false;
    public bool isFind { get; set; } = false;
    public bool repeat { get; set; } = false;
    public bool random { get; set; } = false;
    public bool customSong { get; set; } = false;
}

public class VkDatas
{
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> searchAudios { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> audio { get; set; }
    public long user_id { get; set; }
    public ServiceCollection service { get; set; }
}