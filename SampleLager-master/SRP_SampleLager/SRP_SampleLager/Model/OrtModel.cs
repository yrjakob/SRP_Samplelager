using System;

namespace SRP_SampleLager
{
    public class OrtModel : IOrtModel
    {
        public int RaumId { get; set; }
        public string Ort { get; set; }
        public string oldOrt { get; set; }
        public string Headline { get; set; }
    }
}
