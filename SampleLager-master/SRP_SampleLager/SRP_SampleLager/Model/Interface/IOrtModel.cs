using System;

namespace SRP_SampleLager
{
    public interface IOrtModel
    {
        int RaumId { get; set; }
        string Ort { get; set; }
        string oldOrt { get; set; }
        string Headline { get; set; }
    }
}
