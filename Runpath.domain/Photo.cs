﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Runpath.domain
{
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
