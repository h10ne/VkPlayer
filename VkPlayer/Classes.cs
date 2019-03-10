using Microsoft.Extensions.DependencyInjection;

public class Switches
{
    public bool isPlay { get; set; } = false;
    public bool mute { get; set; } = false;
    public bool isBlack { get; set; } = false;
    public bool IsMaximize { get; set; } = false;
    public bool repeat { get; set; } = false;
    public bool IsSearch { get; set; } = false;
    public bool IsHot { get; set; } = false;
    public bool IsRecommend { get; set; } = false;
    public bool IsOwn { get; set; } = true;
    public bool random { get; set; } = false;
    public bool isId { get; set; } = false;
}

public class VkDatas
{
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> SearchAudios { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> Audio { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> RecommendedAudio { get; set; }
    public VkNet.Utils.VkCollection<VkNet.Model.Attachments.Audio> IdAudios { get; set; }
    public System.Collections.Generic.IEnumerable<VkNet.Model.Attachments.Audio> HotAudios { get; set; }
    public long user_id { get; set; }
    public ServiceCollection service { get; set; }
    public int _offset { get; set; } = -1;
}