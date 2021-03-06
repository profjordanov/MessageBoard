﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using MessageBoard.Data;
using MessageBoard.Models;

namespace MessageBoard.Services
{
    public class PortfolioService : Service
    {
        public IEnumerable<PictureVM> GetPictureVms()
        {
            IEnumerable<Picture> pictures = this.Context.Pictures;
            IEnumerable<PictureVM> vms = Mapper.Instance.Map<IEnumerable<Picture>, IEnumerable<PictureVM>>(pictures);
            return vms;
        }

        public void AddPicture(PictureBM bind)
        {
            Picture model = Mapper.Map<PictureBM, Picture>(bind);
            this.Context.Pictures.Add(model);
            this.Context.SaveChanges();
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}