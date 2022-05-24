﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        void ContentAdd(Content content);
        List<Content> GetListByHeadingID(int id);
        void ContentUpdate(Content content);
        Content GetById(int id);
        void ContentDelete(Content content);
    }
}
