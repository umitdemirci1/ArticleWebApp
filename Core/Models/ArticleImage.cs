﻿using Core.Models.IEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ArticleImage : IEntityBase
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string ContentType { get; set; }
        public string AltText { get; set; }
        public string? Caption { get; set; }
        public int Position { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;

        public Article Article { get; set; } = null!;
    }

}
