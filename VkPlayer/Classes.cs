using Microsoft.Extensions.DependencyInjection;

public class Switches
{
    public bool isPlay { get; set; } = false;
    public bool mute { get; set; } = false;
    public bool isBlack { get; set; } = false;
    public bool isFind { get; set; } = false;
    public bool repeat { get; set; } = false;
    public bool random { get; set; } = false;
}

public class VkDatas
{
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> SearchAudios { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> Audio { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> RecommendedAudio { get; set; }
    public long user_id { get; set; }
    public ServiceCollection service { get; set; }
    public int _offset { get; set; } = -1;
}