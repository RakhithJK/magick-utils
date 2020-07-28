﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagickUtils
{
    using IF = Program.ImageFormat;

    class ConvertTabHelper
    {
        public static void ConvertFileList (string[] files, ComboBox qualityCombox, ComboBox qualityMaxCombox, IF selectedFormat, CheckBox delSrcCbox)
        {
            int qMin = int.Parse(qualityCombox.Text.Trim());
            int qMax = qMin;
            if(!string.IsNullOrWhiteSpace(qualityMaxCombox.Text.Trim()))
                qMax = int.Parse(qualityMaxCombox.Text.Trim());

            foreach(string file in files)
            {
                Program.Print("Convert Dragndrop: " + file);
                if(!IOUtils.IsPathDirectory(file))
                {
                    if(selectedFormat == IF.JPG)
                        ConvertUtils.ConvertToJpegRandomQuality(file, qMin, qMax, delSrcCbox.Checked);

                    if(selectedFormat == IF.PNG)
                        ConvertUtils.ConvertToPng(file, qMin, delSrcCbox.Checked);

                    if(selectedFormat == IF.DDS)
                    {
                        if(FormatOptions.ddsUseCrunch) ConvertUtilsUI.ConvertDirToDdsCrunch(qMin, qMax, delSrcCbox.Checked);
                        else ConvertUtils.ConvertToDds(file, delSrcCbox.Checked);
                    }

                    if(selectedFormat == IF.TGA)
                        ConvertUtils.ConvertToTga(file, delSrcCbox.Checked);

                    if(selectedFormat == IF.WEBP)
                        ConvertUtils.ConvertToWebp(file, qMin, delSrcCbox.Checked);

                    if(selectedFormat == IF.J2K)
                        ConvertUtils.ConvertToJpeg2000(file, qMin, delSrcCbox.Checked);

                    if(selectedFormat == IF.FLIF)
                        FlifInterface.EncodeImage(file, qMin, delSrcCbox.Checked);
                }
            }
        }

        public static void ConvertUsingPath (ComboBox qualityCombox, ComboBox qualityMaxCombox, IF selectedFormat, CheckBox delSrcCbox)
        {
            int qMin = int.Parse(qualityCombox.Text.Trim());
            int qMax = qMin;
            if(!string.IsNullOrWhiteSpace(qualityMaxCombox.Text.Trim()))
                qMax = int.Parse(qualityMaxCombox.Text.Trim());

            if(selectedFormat == IF.JPG)
                ConvertUtilsUI.ConvertDirToJpeg(qMin, qMax, delSrcCbox.Checked);

            if(selectedFormat == IF.PNG)
                ConvertUtilsUI.ConvertDirToPng(qMin, delSrcCbox.Checked);

            if(selectedFormat == IF.DDS)
            {
                if(FormatOptions.ddsUseCrunch) ConvertUtilsUI.ConvertDirToDdsCrunch(qMin, qMax, delSrcCbox.Checked);
                else ConvertUtilsUI.ConvertDirToDds(delSrcCbox.Checked);
            }

            if(selectedFormat == IF.TGA)
                ConvertUtilsUI.ConvertDirToTga(delSrcCbox.Checked);

            if(selectedFormat == IF.WEBP)
                ConvertUtilsUI.ConvertDirToWebp(qMin, delSrcCbox.Checked);

            if(selectedFormat == IF.J2K)
                ConvertUtilsUI.ConvertDirToJpeg2000(qMin, delSrcCbox.Checked);

            if(selectedFormat == IF.FLIF)
                ConvertUtilsUI.ConvertDirToFlif(qMin, delSrcCbox.Checked);
        }
    }
}
