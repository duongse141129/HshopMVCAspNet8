using System;
using System.Collections.Generic;

namespace EcommerceMVC.Data;

public partial class Feedback
{
    public string FeedbackId { get; set; } = null!;

    public int TopicId { get; set; }

    public string Content { get; set; } = null!;

    public DateOnly DateFeedback { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsResponse { get; set; }

    public string? Response { get; set; }

    public DateOnly? DateResponse { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
