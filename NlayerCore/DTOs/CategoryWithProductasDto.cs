﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerCore.DTOs
{
    public class CategoryWithProductasDto:CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}