using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02快速创建图框
{
    public static class Class1
    {
        [CommandMethod("TK")]
        public static void TK()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Color blue = Color.FromRgb(0, 255, 255);
            Color red = Color.FromRgb(255, 0,0);
            Color green = Color.FromRgb(0, 255, 0);
            Color white = Color.FromRgb(255, 255, 255);

            PromptPointResult ppr_1 = ed.GetPoint("请指定图框插入点：");
            //先创建一个A1的图框
            Point3d ppr = ppr_1.Value;

            // 这里再写一个值的传递 

            if (ppr_1.Status == PromptStatus.Cancel) return;
            if (ppr_1.Status == PromptStatus.OK)
            {
                ppr_1 = ed.GetPoint("\n 请指定要插入图框的大小 [A1(A) / A2(B) / A3(C) / A4(D)] ", new string[] { "A", "B", "C", "D" });
                if (ppr_1.Status == PromptStatus.Cancel) return;
                if (ppr_1.Status == PromptStatus.None) return;

                if (ppr_1.Status == PromptStatus.Keyword)
                {

                    switch (ppr_1.StringResult)
                    {
                        case "A":
                            Point3d p0 = ppr;
                            Point2d p1 = new Point2d(p0.X, p0.Y);
                            Point2d p2 = new Point2d(p0.X + 15, p0.Y + 5);
                            Point2d p3 = new Point2d(p0.X + 825, p0.Y + 579);
                            Point2d p4 = new Point2d(p0.X + 830, p0.Y + 584);

                            db.AddRectToModelSpace(p1, p4);
                            db.AddRectToModelSpace(p2, p3);                      
                           
                            //人工设置基准点
                            Point3d Bsae_1 = new Point3d(0, 0, 0);
                            Bsae_1 = new Point3d (p0.X + 645, p0.Y + 5, 0);
                            db.AddTextBar(Bsae_1);

                            DBText[] text = new DBText[11];
                            // 找一个初始值的点
                            Point3d[] pd1 = new Point3d[11];
                            for (int i = 0; i < text.Length; i++)
                            {
                                pd1[i] = new Point3d(p0.X + 3.3987, p0.Y + 61.3217 + 20 * i, 0);
                                // [i].Position = pd1[i];
                                // text[i].Height = 5;
                                // text[i].TextString = name[i];
                                // db.AddEntityToModeSpace(text[i]);
                            }
                            // 添加文字信息
                            using (Transaction trans = db.TransactionManager.StartTransaction())
                            {
                                DBText text0 = new DBText(); // 新建单行文本对象
                                text0.Position = pd1[0]; // 设置文本位置 
                                text0.TextString = "资 料"; // 设置文本内容
                                text0.Height = 5;  // 设置文本高度
                                text0.HorizontalMode = TextHorizontalMode.TextLeft; // 设置对齐方式

                                text0.WidthFactor = 0.9;
                                text0.Color = blue;


                                // "ISO Proportional ";
                                // text0.AlignmentPoint = text0.Position; //设置对齐点
                                db.AddEntityToModeSpace(text0);

                                DBText text1 = new DBText(); // 新建单行文本对象
                                text1.Position = pd1[1];
                                text1.TextString = "设 计";
                                text1.Height = 5;
                                text1.HorizontalMode = TextHorizontalMode.TextLeft;

                                text1.WidthFactor = 0.9;
                                text1.Color = blue;

                                // text1.AlignmentPoint = text1.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text1);

                                DBText text2 = new DBText(); // 新建单行文本对象
                                text2.Position = pd1[2];
                                text2.TextString = "质 检";
                                text2.Height = 5;
                                text2.HorizontalMode = TextHorizontalMode.TextLeft;

                                text2.WidthFactor = 0.9;
                                text2.Color = blue;

                                // text2.AlignmentPoint = text2.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text2);

                                DBText text3 = new DBText(); // 新建单行文本对象
                                text3.Position = pd1[3];
                                text3.TextString = "售 后";
                                text3.Height = 5;
                                text3.HorizontalMode = TextHorizontalMode.TextLeft;

                                text3.WidthFactor = 0.9;
                                text3.Color = blue;

                                // text3.AlignmentPoint = text3.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text3);

                                DBText text4 = new DBText(); // 新建单行文本对象
                                text4.Position = pd1[4];
                                text4.TextString = "试 验";
                                text4.Height = 5;
                                text4.HorizontalMode = TextHorizontalMode.TextLeft;

                                text4.WidthFactor = 0.9;
                                text4.Color = blue;

                                // text4.AlignmentPoint = text4.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text4);

                                DBText text5 = new DBText(); // 新建单行文本对象
                                text5.Position = pd1[5];
                                text5.TextString = "部 件";
                                text5.Height = 5;
                                text5.HorizontalMode = TextHorizontalMode.TextLeft;

                                text5.WidthFactor = 0.9;
                                text5.Color = blue;

                                //  text5.AlignmentPoint = text5.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text5);

                                DBText text6 = new DBText(); // 新建单行文本对象
                                text6.Position = pd1[6];
                                text6.TextString = "干 变";
                                text6.Height = 5;
                                text6.HorizontalMode = TextHorizontalMode.TextLeft;

                                text6.WidthFactor = 0.9;
                                text6.Color = blue;

                                // text6.AlignmentPoint = text6.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text6);

                                DBText text7 = new DBText(); // 新建单行文本对象
                                text7.Position = pd1[7];
                                text7.TextString = "油 变";
                                text7.Height = 5;
                                text7.HorizontalMode = TextHorizontalMode.TextLeft;

                                text7.WidthFactor = 0.9;
                                text7.Color = blue;

                                // text7.AlignmentPoint = text7.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text7);

                                DBText text8 = new DBText(); // 新建单行文本对象
                                text8.Position = pd1[8];
                                text8.TextString = "综 合";
                                text8.Height = 5;
                                text8.HorizontalMode = TextHorizontalMode.TextLeft;

                                text8.WidthFactor = 0.9;
                                text8.Color = blue;

                                // text8.AlignmentPoint = text8.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text8);

                                DBText text9 = new DBText(); // 新建单行文本对象
                                text9.Position = pd1[9];
                                text9.TextString = "供 应";
                                text9.Height = 5;
                                text9.HorizontalMode = TextHorizontalMode.TextLeft;

                                text9.WidthFactor = 0.9;
                                text9.Color = blue;

                                // text9.AlignmentPoint = text9.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text9);

                                DBText text10 = new DBText(); // 新建单行文本对象
                                text10.Position = pd1[10];
                                text10.TextString = "生 产";
                                text10.Height = 5;
                                text10.HorizontalMode = TextHorizontalMode.TextLeft;

                                text10.WidthFactor = 0.9;
                                text10.Color = blue;

                                // text10.AlignmentPoint = text10.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text10);
                                
                                trans.Commit();

                                

                            }
                            break;

                        case "B":
                            Point3d p5 = ppr;
                            Point2d p6 = new Point2d(p5.X, p5.Y);
                            Point2d p7 = new Point2d(p5.X + 15, p5.Y + 5);
                            Point2d p8 = new Point2d(p5.X + 579, p5.Y + 405);
                            Point2d p9 = new Point2d(p5.X + 584, p5.Y + 410);

                            db.AddRectToModelSpace(p6, p9);
                            db.AddRectToModelSpace(p7, p8);

                            //人工设置基准点
                            Point3d Bsae_2 = new Point3d(0, 0, 0);
                            Bsae_2 = new Point3d(p5.X + 399, p5.Y + 5, 0);
                            db.AddTextBar(Bsae_2);

                            DBText[] text_2 = new DBText[11];
                            // 找一个初始值的点
                            Point3d[] pd2 = new Point3d[11];
                            for (int i = 0; i < text_2.Length; i++)
                            {
                                pd2[i] = new Point3d(p5.X + 3.3987, p5.Y + 61.3217 + 20 * i, 0);
                                // [i].Position = pd1[i];
                                // text[i].Height = 5;
                                // text[i].TextString = name[i];
                                // db.AddEntityToModeSpace(text[i]);
                            }
                            // 添加文字信息
                            using (Transaction trans = db.TransactionManager.StartTransaction())
                            {
                                DBText text0 = new DBText(); // 新建单行文本对象
                                text0.Position = pd2[0]; // 设置文本位置 
                                text0.TextString = "资 料"; // 设置文本内容
                                text0.Height = 5;  // 设置文本高度
                                text0.HorizontalMode = TextHorizontalMode.TextLeft; // 设置对齐方式

                                text0.WidthFactor = 0.9;
                                text0.Color = blue;


                                // "ISO Proportional ";
                                // text0.AlignmentPoint = text0.Position; //设置对齐点
                                db.AddEntityToModeSpace(text0);

                                DBText text1 = new DBText(); // 新建单行文本对象
                                text1.Position = pd2[1];
                                text1.TextString = "设 计";
                                text1.Height = 5;
                                text1.HorizontalMode = TextHorizontalMode.TextLeft;

                                text1.WidthFactor = 0.9;
                                text1.Color = blue;

                                // text1.AlignmentPoint = text1.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text1);

                                DBText text2 = new DBText(); // 新建单行文本对象
                                text2.Position = pd2[2];
                                text2.TextString = "质 检";
                                text2.Height = 5;
                                text2.HorizontalMode = TextHorizontalMode.TextLeft;

                                text2.WidthFactor = 0.9;
                                text2.Color = blue;

                                // text2.AlignmentPoint = text2.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text2);

                                DBText text3 = new DBText(); // 新建单行文本对象
                                text3.Position = pd2[3];
                                text3.TextString = "售 后";
                                text3.Height = 5;
                                text3.HorizontalMode = TextHorizontalMode.TextLeft;

                                text3.WidthFactor = 0.9;
                                text3.Color = blue;

                                // text3.AlignmentPoint = text3.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text3);

                                DBText text4 = new DBText(); // 新建单行文本对象
                                text4.Position = pd2[4];
                                text4.TextString = "试 验";
                                text4.Height = 5;
                                text4.HorizontalMode = TextHorizontalMode.TextLeft;

                                text4.WidthFactor = 0.9;
                                text4.Color = blue;

                                // text4.AlignmentPoint = text4.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text4);

                                DBText text5 = new DBText(); // 新建单行文本对象
                                text5.Position = pd2[5];
                                text5.TextString = "部 件";
                                text5.Height = 5;
                                text5.HorizontalMode = TextHorizontalMode.TextLeft;

                                text5.WidthFactor = 0.9;
                                text5.Color = blue;

                                //  text5.AlignmentPoint = text5.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text5);

                                DBText text6 = new DBText(); // 新建单行文本对象
                                text6.Position = pd2[6];
                                text6.TextString = "干 变";
                                text6.Height = 5;
                                text6.HorizontalMode = TextHorizontalMode.TextLeft;

                                text6.WidthFactor = 0.9;
                                text6.Color = blue;

                                // text6.AlignmentPoint = text6.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text6);

                                DBText text7 = new DBText(); // 新建单行文本对象
                                text7.Position = pd2[7];
                                text7.TextString = "油 变";
                                text7.Height = 5;
                                text7.HorizontalMode = TextHorizontalMode.TextLeft;

                                text7.WidthFactor = 0.9;
                                text7.Color = blue;

                                // text7.AlignmentPoint = text7.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text7);

                                DBText text8 = new DBText(); // 新建单行文本对象
                                text8.Position = pd2[8];
                                text8.TextString = "综 合";
                                text8.Height = 5;
                                text8.HorizontalMode = TextHorizontalMode.TextLeft;

                                text8.WidthFactor = 0.9;
                                text8.Color = blue;

                                // text8.AlignmentPoint = text8.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text8);

                                DBText text9 = new DBText(); // 新建单行文本对象
                                text9.Position = pd2[9];
                                text9.TextString = "供 应";
                                text9.Height = 5;
                                text9.HorizontalMode = TextHorizontalMode.TextLeft;

                                text9.WidthFactor = 0.9;
                                text9.Color = blue;

                                // text9.AlignmentPoint = text9.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text9);

                                DBText text10 = new DBText(); // 新建单行文本对象
                                text10.Position = pd2[10];
                                text10.TextString = "生 产";
                                text10.Height = 5;
                                text10.HorizontalMode = TextHorizontalMode.TextLeft;

                                text10.WidthFactor = 0.9;
                                text10.Color = blue;

                                // text10.AlignmentPoint = text10.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text10);

                                trans.Commit();

                            }
                            break;

                        case "C":
                            Point3d p10 = ppr;
                            Point2d p11 = new Point2d(p10.X, p10.Y);
                            Point2d p12 = new Point2d(p10.X + 15, p10.Y + 5);
                            Point2d p13 = new Point2d(p10.X + 405, p10.Y + 282);
                            Point2d p14 = new Point2d(p10.X + 410, p10.Y + 287);

                            db.AddRectToModelSpace(p11, p14);
                            db.AddRectToModelSpace(p12, p13);

                            //人工设置基准点
                            Point3d Bsae_3 = new Point3d(0, 0, 0);
                            Bsae_3 = new Point3d(p10.X + 225, p10.Y + 5, 0);
                            db.AddTextBar(Bsae_3);

                            DBText[] text_3 = new DBText[11];
                            // 找一个初始值的点
                            Point3d[] pd3 = new Point3d[11];
                            for (int i = 0; i < text_3.Length; i++)
                            {
                                pd3[i] = new Point3d(p10.X + 3.3987, p10.Y + 41.3217 + 20 * i, 0);
                                // [i].Position = pd1[i];
                                // text[i].Height = 5;
                                // text[i].TextString = name[i];
                                // db.AddEntityToModeSpace(text[i]);
                            }
                            // 添加文字信息
                            using (Transaction trans = db.TransactionManager.StartTransaction())
                            {
                                DBText text0 = new DBText(); // 新建单行文本对象
                                text0.Position = pd3[0]; // 设置文本位置 
                                text0.TextString = "资 料"; // 设置文本内容
                                text0.Height = 5;  // 设置文本高度
                                text0.HorizontalMode = TextHorizontalMode.TextLeft; // 设置对齐方式

                                text0.WidthFactor = 0.9;
                                text0.Color = blue;


                                // "ISO Proportional ";
                                // text0.AlignmentPoint = text0.Position; //设置对齐点
                                db.AddEntityToModeSpace(text0);

                                DBText text1 = new DBText(); // 新建单行文本对象
                                text1.Position = pd3[1];
                                text1.TextString = "设 计";
                                text1.Height = 5;
                                text1.HorizontalMode = TextHorizontalMode.TextLeft;

                                text1.WidthFactor = 0.9;
                                text1.Color = blue;

                                // text1.AlignmentPoint = text1.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text1);

                                DBText text2 = new DBText(); // 新建单行文本对象
                                text2.Position = pd3[2];
                                text2.TextString = "质 检";
                                text2.Height = 5;
                                text2.HorizontalMode = TextHorizontalMode.TextLeft;

                                text2.WidthFactor = 0.9;
                                text2.Color = blue;

                                // text2.AlignmentPoint = text2.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text2);

                                DBText text3 = new DBText(); // 新建单行文本对象
                                text3.Position = pd3[3];
                                text3.TextString = "售 后";
                                text3.Height = 5;
                                text3.HorizontalMode = TextHorizontalMode.TextLeft;

                                text3.WidthFactor = 0.9;
                                text3.Color = blue;

                                // text3.AlignmentPoint = text3.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text3);

                                DBText text4 = new DBText(); // 新建单行文本对象
                                text4.Position = pd3[4];
                                text4.TextString = "试 验";
                                text4.Height = 5;
                                text4.HorizontalMode = TextHorizontalMode.TextLeft;

                                text4.WidthFactor = 0.9;
                                text4.Color = blue;

                                // text4.AlignmentPoint = text4.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text4);

                                DBText text5 = new DBText(); // 新建单行文本对象
                                text5.Position = pd3[5];
                                text5.TextString = "部 件";
                                text5.Height = 5;
                                text5.HorizontalMode = TextHorizontalMode.TextLeft;

                                text5.WidthFactor = 0.9;
                                text5.Color = blue;

                                //  text5.AlignmentPoint = text5.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text5);

                                DBText text6 = new DBText(); // 新建单行文本对象
                                text6.Position = pd3[6];
                                text6.TextString = "干 变";
                                text6.Height = 5;
                                text6.HorizontalMode = TextHorizontalMode.TextLeft;

                                text6.WidthFactor = 0.9;
                                text6.Color = blue;

                                // text6.AlignmentPoint = text6.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text6);

                                DBText text7 = new DBText(); // 新建单行文本对象
                                text7.Position = pd3[7];
                                text7.TextString = "油 变";
                                text7.Height = 5;
                                text7.HorizontalMode = TextHorizontalMode.TextLeft;

                                text7.WidthFactor = 0.9;
                                text7.Color = blue;

                                // text7.AlignmentPoint = text7.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text7);

                                DBText text8 = new DBText(); // 新建单行文本对象
                                text8.Position = pd3[8];
                                text8.TextString = "综 合";
                                text8.Height = 5;
                                text8.HorizontalMode = TextHorizontalMode.TextLeft;

                                text8.WidthFactor = 0.9;
                                text8.Color = blue;

                                // text8.AlignmentPoint = text8.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text8);

                                DBText text9 = new DBText(); // 新建单行文本对象
                                text9.Position = pd3[9];
                                text9.TextString = "供 应";
                                text9.Height = 5;
                                text9.HorizontalMode = TextHorizontalMode.TextLeft;

                                text9.WidthFactor = 0.9;
                                text9.Color = blue;

                                // text9.AlignmentPoint = text9.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text9);

                                DBText text10 = new DBText(); // 新建单行文本对象
                                text10.Position = pd3[10];
                                text10.TextString = "生 产";
                                text10.Height = 5;
                                text10.HorizontalMode = TextHorizontalMode.TextLeft;

                                text10.WidthFactor = 0.9;
                                text10.Color = blue;

                                // text10.AlignmentPoint = text10.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text10);

                                trans.Commit();

                            }
                            break;


                        case "D":
                            Point3d p20 = ppr;
                            Point2d p21 = new Point2d(p20.X, p20.Y);
                            Point2d p22 = new Point2d(p20.X + 15, p20.Y + 5);
                            Point2d p23 = new Point2d(p20.X + 195, p20.Y + 282);
                            Point2d p24 = new Point2d(p20.X + 200, p20.Y + 287);

                            db.AddRectToModelSpace(p21, p24);
                            db.AddRectToModelSpace(p22, p23);

                            //人工设置基准点
                            Point3d Bsae_4 = new Point3d(0, 0, 0);
                            Bsae_4 = new Point3d(p20.X + 15, p20.Y + 5, 0);
                            db.AddTextBar(Bsae_4);

                            DBText[] text_4 = new DBText[11];
                            // 找一个初始值的点
                            Point3d[] pd4 = new Point3d[11];
                            for (int i = 0; i < text_4.Length; i++)
                            {
                                pd4[i] = new Point3d(p20.X + 3.3987, p20.Y + 41.3217 + 20 * i, 0);
                                // [i].Position = pd1[i];
                                // text[i].Height = 5;
                                // text[i].TextString = name[i];
                                // db.AddEntityToModeSpace(text[i]);
                            }
                            // 添加文字信息
                            using (Transaction trans = db.TransactionManager.StartTransaction())
                            {
                                DBText text0 = new DBText(); // 新建单行文本对象
                                text0.Position = pd4[0]; // 设置文本位置 
                                text0.TextString = "资 料"; // 设置文本内容
                                text0.Height = 5;  // 设置文本高度
                                text0.HorizontalMode = TextHorizontalMode.TextLeft; // 设置对齐方式

                                text0.WidthFactor = 0.9;
                                text0.Color = blue;


                                // "ISO Proportional ";
                                // text0.AlignmentPoint = text0.Position; //设置对齐点
                                db.AddEntityToModeSpace(text0);

                                DBText text1 = new DBText(); // 新建单行文本对象
                                text1.Position = pd4[1];
                                text1.TextString = "设 计";
                                text1.Height = 5;
                                text1.HorizontalMode = TextHorizontalMode.TextLeft;

                                text1.WidthFactor = 0.9;
                                text1.Color = blue;

                                // text1.AlignmentPoint = text1.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text1);

                                DBText text2 = new DBText(); // 新建单行文本对象
                                text2.Position = pd4[2];
                                text2.TextString = "质 检";
                                text2.Height = 5;
                                text2.HorizontalMode = TextHorizontalMode.TextLeft;

                                text2.WidthFactor = 0.9;
                                text2.Color = blue;

                                // text2.AlignmentPoint = text2.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text2);

                                DBText text3 = new DBText(); // 新建单行文本对象
                                text3.Position = pd4[3];
                                text3.TextString = "售 后";
                                text3.Height = 5;
                                text3.HorizontalMode = TextHorizontalMode.TextLeft;

                                text3.WidthFactor = 0.9;
                                text3.Color = blue;

                                // text3.AlignmentPoint = text3.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text3);

                                DBText text4 = new DBText(); // 新建单行文本对象
                                text4.Position = pd4[4];
                                text4.TextString = "试 验";
                                text4.Height = 5;
                                text4.HorizontalMode = TextHorizontalMode.TextLeft;

                                text4.WidthFactor = 0.9;
                                text4.Color = blue;

                                // text4.AlignmentPoint = text4.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text4);

                                DBText text5 = new DBText(); // 新建单行文本对象
                                text5.Position = pd4[5];
                                text5.TextString = "部 件";
                                text5.Height = 5;
                                text5.HorizontalMode = TextHorizontalMode.TextLeft;

                                text5.WidthFactor = 0.9;
                                text5.Color = blue;

                                //  text5.AlignmentPoint = text5.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text5);

                                DBText text6 = new DBText(); // 新建单行文本对象
                                text6.Position = pd4[6];
                                text6.TextString = "干 变";
                                text6.Height = 5;
                                text6.HorizontalMode = TextHorizontalMode.TextLeft;

                                text6.WidthFactor = 0.9;
                                text6.Color = blue;

                                // text6.AlignmentPoint = text6.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text6);

                                DBText text7 = new DBText(); // 新建单行文本对象
                                text7.Position = pd4[7];
                                text7.TextString = "油 变";
                                text7.Height = 5;
                                text7.HorizontalMode = TextHorizontalMode.TextLeft;

                                text7.WidthFactor = 0.9;
                                text7.Color = blue;

                                // text7.AlignmentPoint = text7.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text7);

                                DBText text8 = new DBText(); // 新建单行文本对象
                                text8.Position = pd4[8];
                                text8.TextString = "综 合";
                                text8.Height = 5;
                                text8.HorizontalMode = TextHorizontalMode.TextLeft;

                                text8.WidthFactor = 0.9;
                                text8.Color = blue;

                                // text8.AlignmentPoint = text8.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text8);

                                DBText text9 = new DBText(); // 新建单行文本对象
                                text9.Position = pd4[9];
                                text9.TextString = "供 应";
                                text9.Height = 5;
                                text9.HorizontalMode = TextHorizontalMode.TextLeft;

                                text9.WidthFactor = 0.9;
                                text9.Color = blue;

                                // text9.AlignmentPoint = text9.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text9);

                                DBText text10 = new DBText(); // 新建单行文本对象
                                text10.Position = pd4[10];
                                text10.TextString = "生 产";
                                text10.Height = 5;
                                text10.HorizontalMode = TextHorizontalMode.TextLeft;

                                text10.WidthFactor = 0.9;
                                text10.Color = blue;

                                // text10.AlignmentPoint = text10.Position; // 设置对齐点
                                db.AddEntityToModeSpace(text10);

                                trans.Commit();

                            }
                            break;


                    }

                }  

            }

        }

        [CommandMethod("CK")]
        public static void CK()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Color blue = Color.FromRgb(0, 255, 255);
            Color red = Color.FromRgb(255, 0, 0);
            Color green = Color.FromRgb(0, 255, 0);
            Color white = Color.FromRgb(255, 255, 255);
            //人工设置基准点
            Point3d Bsae = new Point3d(0, 0, 0);

            // 第一部分的程序(线框)
            // 横线
            Line[] L_one_1 = new Line[5];
            Point3d[] P_one_1 = new Point3d[5];
            Point3d[] P_one_2 = new Point3d[5];
            for (int i = 0; i < L_one_1.Length; i++)
            {
                P_one_1[i] = new Point3d(Bsae.X, Bsae.Y +  5 + 5 * i, 0);
                P_one_2[i] = new Point3d(Bsae.X + 63, Bsae.Y + 5 + 5 * i, 0);
                L_one_1[i] = new Line(P_one_1[i], P_one_2[i]);
                L_one_1[i].Color = red;
            }

            // 竖线
            Line[] L_one_2 = new Line[4];
            Point3d[] P_one_3 = new Point3d[4];
            Point3d[] P_one_4 = new Point3d[4];
            //Point3d P_one_3 = new Point3d(0, 0, 0);
            //Point3d P_one_4 = new Point3d(0, 30, 0);
            double[] I_one_1 = new double[4] { 0, 14, 38.5, 63 };
            for (int i = 0; i < I_one_1.Length; i++)
            {
                P_one_3[i] = new Point3d(Bsae.X + I_one_1[i], Bsae.Y + 0, 0);
                P_one_4[i] = new Point3d(Bsae.X + I_one_1[i], Bsae.Y + 30, 0);
                L_one_2[i] = new Line(P_one_3[i], P_one_4[i]);
                L_one_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_one_1);
            db.AddEntityToModeSpace(L_one_2);

            // 第二部分的程序(线框)
            // 横线
            Line[] L_two_1 = new Line[3];
            Point3d[] P_two_1 = new Point3d[3];
            Point3d[] P_two_2 = new Point3d[3];
            for (int i = 0; i < L_two_1.Length; i++)
            {
                P_two_1[i] = new Point3d(Bsae.X + 0, Bsae.Y + 30 + 5 * i, 0);
                P_two_2[i] = new Point3d(Bsae.X + 63, Bsae.Y + 30 + 5 * i, 0);
                L_two_1[i] = new Line(P_two_1[i], P_two_2[i]);
                L_two_1[i].Color = red;
            }
            // 竖线
            Line[] L_two_2 = new Line[6];
            Point3d[] P_two_3 = new Point3d[6];
            Point3d[] P_two_4 = new Point3d[6];
            //Point3d P_one_3 = new Point3d(0, 0, 0);
            //Point3d P_one_4 = new Point3d(0, 30, 0);
            double[] I_two_1 = new double[6] { 0, 8.5, 14, 31, 46, 63};
            for (int i = 0; i < I_two_1.Length; i++)
            {
                P_two_3[i] = new Point3d(Bsae.X + I_two_1[i], Bsae.Y + 30, 0);
                P_two_4[i] = new Point3d(Bsae.X + I_two_1[i], Bsae.Y + 45, 0);
                L_two_2[i] = new Line(P_two_3[i], P_two_4[i]);
                L_two_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_two_1);
            db.AddEntityToModeSpace(L_two_2);

            // 第三部分的程序(线框)
            // 横线
            Line[] L_three_1 = new Line[2];
            Point3d[] P_three_1 = new Point3d[2];
            Point3d[] P_three_2 = new Point3d[2];
            for (int i = 0; i < L_three_1.Length; i++)
            {
                P_three_1[i] = new Point3d(Bsae.X + 0, Bsae.Y + 45 + 8 * i, 0);
                P_three_2[i] = new Point3d(Bsae.X + 180, Bsae.Y + 45 + 8 * i, 0);
                L_three_1[i] = new Line(P_three_1[i], P_three_2[i]);
                L_three_1[i].Color = red;
            }
            // 竖线
            Line[] L_three_2 = new Line[7];
            Point3d[] P_three_3 = new Point3d[7];
            Point3d[] P_three_4 = new Point3d[7];
            //Point3d P_one_3 = new Point3d(0, 0, 0);
            //Point3d P_one_4 = new Point3d(0, 30, 0);
            double[] I_three_1 = new double[7] { 0, 8, 48, 92, 100, 138 ,160};
            for (int i = 0; i < I_three_1.Length; i++)
            {
                P_three_3[i] = new Point3d(Bsae.X + I_three_1[i], Bsae.Y + 45, 0);
                P_three_4[i] = new Point3d(Bsae.X + I_three_1[i], Bsae.Y + 53, 0);
                L_three_2[i] = new Line(P_three_3[i], P_three_4[i]);
                L_three_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_three_1);
            db.AddEntityToModeSpace(L_three_2);

            // 第四部分的程序(线框)
            // 横线
            Line[] L_four_1 = new Line[2];
            Point3d[] P_four_1 = new Point3d[2];
            Point3d[] P_four_2 = new Point3d[2];
            for (int i = 0; i < L_four_1.Length; i++)
            {
                P_four_1[i] = new Point3d(Bsae.X + 63, Bsae.Y + 35 + 10 * i, 0);
                P_four_2[i] = new Point3d(Bsae.X + 180, Bsae.Y + 35 + 10 * i, 0);
                L_four_1[i] = new Line(P_four_1[i], P_four_2[i]);
                L_four_1[i].Color = red;
            }
            // 竖线
            Line[] L_four_2 = new Line[3];
            Point3d[] P_four_3 = new Point3d[3];
            Point3d[] P_four_4 = new Point3d[3];
            double[] I_four_1 = new double[3] { 63, 75, 138 };
            for (int i = 0; i < I_four_1.Length; i++)
            {
                P_four_3[i] = new Point3d(Bsae.X + 0 + I_four_1[i], Bsae.Y + 35, 0);
                P_four_4[i] = new Point3d(Bsae.X + 0 + I_four_1[i], Bsae.Y + 45, 0);
                L_four_2[i] = new Line(P_four_3[i], P_four_4[i]);
                L_four_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_four_1);
            db.AddEntityToModeSpace(L_four_2);

            // 第五部分的程序(线框)
            // 横线
            Line[] L_five_1 = new Line[5];
            Point3d[] P_five_1 = new Point3d[5];
            Point3d[] P_five_2 = new Point3d[5];
            for (int i = 0; i < L_five_1.Length; i++)
            {
                P_five_1[i] = new Point3d(Bsae.X + 124, Bsae.Y + 7 + 7 * i, 0);
                P_five_2[i] = new Point3d(Bsae.X + 180, Bsae.Y + 7 + 7 * i, 0);
                L_five_1[i] = new Line(P_five_1[i], P_five_2[i]);
                L_five_1[i].Color = red;
            }
            // 竖线
            Line[] L_five_2 = new Line[4];
            Point3d[] P_five_3 = new Point3d[4];
            Point3d[] P_five_4 = new Point3d[4];
            double[] I_five_1 = new double[4] { 124, 138, 152,166 };
            for (int i = 0; i < I_five_1.Length; i++)
            {
                P_five_3[i] = new Point3d(Bsae.X + 0 + I_five_1[i], Bsae.Y + 21, 0);
                P_five_4[i] = new Point3d(Bsae.X + 0 + I_five_1[i], Bsae.Y + 35, 0);
                L_five_2[i] = new Line(P_five_3[i], P_five_4[i]);
                L_five_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_five_1);
            db.AddEntityToModeSpace(L_five_2);

            // 第六部分的程序(线框)
            // 横线
            Line[] L_six_1 = new Line[2];
            Point3d[] P_six_1 = new Point3d[2];
            Point3d[] P_six_2 = new Point3d[2];
            for (int i = 0; i < L_six_1.Length; i++)
            {
                P_six_1[i] = new Point3d(Bsae.X + 63, Bsae.Y + 10 + 25 * i, 0);
                P_six_2[i] = new Point3d(Bsae.X + 124, Bsae.Y + 10 + 25 * i, 0);
                L_six_1[i] = new Line(P_six_1[i], P_six_2[i]);
                L_six_1[i].Color = red;
            }
            // 竖线
            Line[] L_six_2 = new Line[3];
            Point3d[] P_six_3 = new Point3d[3];
            Point3d[] P_six_4 = new Point3d[3];
            double[] I_six_1 = new double[3] { 63, 75, 124 };
            for (int i = 0; i < I_six_1.Length; i++)
            {
                P_six_3[i] = new Point3d(Bsae.X + 0 + I_six_1[i], Bsae.Y + 0, 0);
                P_six_4[i] = new Point3d(Bsae.X + 0 + I_six_1[i], Bsae.Y + 35, 0);
                L_six_2[i] = new Line(P_six_3[i], P_six_4[i]);
                L_six_2[i].Color = red;
            }

            db.AddEntityToModeSpace(L_six_1);
            db.AddEntityToModeSpace(L_six_2);

            // 其他(线框)
            // 横线
            Point3d P_else_1 = new Point3d(Bsae.X + 138, Bsae.Y + 49, 0);
            Point3d P_else_2 = new Point3d(Bsae.X + 160, Bsae.Y + 49, 0);
            Line L_else_1 = new Line(P_else_1, P_else_2);
            L_else_1.Color = red;
            // 竖线
            Point3d P_else_3 = new Point3d(Bsae.X + 149, Bsae.Y + 49, 0);
            Point3d P_else_4 = new Point3d(Bsae.X + 149, Bsae.Y + 53, 0);
            Line L_else_2 = new Line(P_else_3, P_else_4);
            L_else_2.Color = red;

            Point3d P_else_5 = new Point3d(Bsae.X + 143.2058, Bsae.Y + 7, 0);
            Point3d P_else_6 = new Point3d(Bsae.X + 143.2058, Bsae.Y + 14, 0);
            Line L_else_3 = new Line(P_else_5, P_else_6);
            L_else_3.Color = red;

            db.AddEntityToModeSpace(L_else_1, L_else_2, L_else_3);



            // 文字信息
            // 第一部分文字信息-蓝字
            string str_1 = "审    定";
            db.AddTextToModelSpace(str_1, new Point3d(Bsae.X + 3.0215, Bsae.Y + 1.2096, 0));
            string str_2 = "会    签";
            db.AddTextToModelSpace(str_2, new Point3d(Bsae.X + 3.0215, Bsae.Y + 6.2096, 0));
            string str_3 = "标准检查";
            db.AddTextToModelSpace(str_3, new Point3d(Bsae.X + 3.0215, Bsae.Y + 11.2096, 0));
            string str_4 = "审    核";
            db.AddTextToModelSpace(str_4, new Point3d(Bsae.X + 3.0215, Bsae.Y + 16.2096, 0));
            string str_5 = "校    核";
            db.AddTextToModelSpace(str_5, new Point3d(Bsae.X + 3.0215, Bsae.Y + 21.2096, 0));
            string str_6 = "设    计";
            db.AddTextToModelSpace(str_6, new Point3d(Bsae.X + 3.0215, Bsae.Y + 26.2096, 0));
            // 第二部分文字信息-蓝字
            string str_7 = "更改标记";
            db.AddTextToModelSpace(str_7, new Point3d(Bsae.X + 0.3191, Bsae.Y + 31.193, 0));
            string str_8 = "处数";
            db.AddTextToModelSpace(str_8, new Point3d(Bsae.X + 9.3191, Bsae.Y + 31.193, 0));
            // 第三部分文字信息-蓝字
            string str_9 = "序 号";
            db.AddTextToModelSpace(str_9, new Point3d(Bsae.X + 1.5392, Bsae.Y + 47.7261, 0));
            string str_10 = "代        号";
            db.AddTextToModelSpace(str_10, new Point3d(Bsae.X + 21.7443, Bsae.Y + 47.7261, 0));
            string str_11 = "名        称";
            db.AddTextToModelSpace(str_11, new Point3d(Bsae.X + 63.7294, Bsae.Y + 47.7261, 0));
            string str_12 = "数 量";
            db.AddTextToModelSpace(str_12, new Point3d(Bsae.X + 93.5243, Bsae.Y + 47.7261, 0));
            string str_13 = "材        料";
            db.AddTextToModelSpace(str_13, new Point3d(Bsae.X + 112.7146, Bsae.Y + 47.7261, 0));
            string str_14 = "单 件";
            db.AddTextToModelSpace(str_14, new Point3d(Bsae.X + 140.9797, Bsae.Y + 49.7096, 0));
            string str_15 = "总 计";
            db.AddTextToModelSpace(str_15, new Point3d(Bsae.X + 151.9499, Bsae.Y + 49.7096, 0));
            string str_16 = "重    量";
            db.AddTextToModelSpace(str_16, new Point3d(Bsae.X + 144.8894, Bsae.Y + 45.7261, 0));
            string str_17 = "备    注";
            db.AddTextToModelSpace(str_17, new Point3d(Bsae.X + 165.8894, Bsae.Y + 47.7261, 0));
            // 第四部分文字信息-蓝字
            string str_18 = "产品型号";
            db.AddTextToModelSpace(str_18, new Point3d(Bsae.X + 65.1138, Bsae.Y + 41.2096, 0));
            string str_19 = "名  称";
            db.AddTextToModelSpace(str_19, new Point3d(Bsae.X + 65.1138, Bsae.Y + 36.2096, 0));
            string str_20 = "图  号";
            db.AddTextToModelSpace(str_20, new Point3d(Bsae.X + 127.395 , Bsae.Y + 38.7426, 0));
            // 第五部分文字信息-蓝字
            string str_21 = "标  记";
            db.AddTextToModelSpace(str_21, new Point3d(Bsae.X + 127.9546, Bsae.Y + 30.193, 0));
            string str_22 = "件  数";
            db.AddTextToModelSpace(str_22, new Point3d(Bsae.X + 141.9992, Bsae.Y + 30.193, 0));
            string str_23 = "重  量";
            db.AddTextToModelSpace(str_23, new Point3d(Bsae.X + 155.9694, Bsae.Y + 30.193, 0));
            string str_24 = "比  例";
            db.AddTextToModelSpace(str_24, new Point3d(Bsae.X + 169.9397, Bsae.Y + 30.193, 0));
            string str_25 = "第        页            共        页";
            db.AddTextToModelSpace(str_25, new Point3d(Bsae.X + 133.0236, Bsae.Y + 16.2261, 0));
            string str_26 = "所属部分";
            db.AddTextToModelSpace(str_26, new Point3d(Bsae.X + 130.084, Bsae.Y + 9.2426, 0));
            string str_27 = "中铁电气工业有限公司";
            db.AddTextToModelSpace(str_27, new Point3d(Bsae.X + 140.7762, Bsae.Y + 1.8015, 0));
            // 第六部分文字信息-蓝字
            string str_28 = "零  件";
            db.AddTextToModelSpace(str_28, new Point3d(Bsae.X + 65.9546, Bsae.Y + 26.2096, 0));
            string str_29 = "名  称";
            db.AddTextToModelSpace(str_29, new Point3d(Bsae.X + 65.9546, Bsae.Y + 16.2096, 0));
            string str_30 = "材  料";
            db.AddTextToModelSpace(str_30, new Point3d(Bsae.X + 65.9546, Bsae.Y + 3.693, 0));
            // 绿字
            string str_31 = "SZ10-88888/888";
            db.AddTextToModelSpaceG(str_31, new Point3d(Bsae.X + 79.7352, Bsae.Y + 36.4002, 0));
            string str_32 = "5DQ.888.8888.88";
            db.AddTextToModelSpaceG(str_32, new Point3d(Bsae.X + 139.56, Bsae.Y + 36.4002, 0));
            string str_33 = "高压绝缘子支板";
            db.AddTextToModelSpaceG(str_33, new Point3d(Bsae.X + 85.5334, Bsae.Y + 18.5362, 0));
            string str_34 = "钢板 20 Q235-A";
            db.AddTextToModelSpaceG(str_34, new Point3d(Bsae.X + 82.9739, Bsae.Y + 1.5486, 0));
            string str_35 = "8888";
            db.AddTextToModelSpaceG(str_35, new Point3d(Bsae.X + 139.33, Bsae.Y + 20.9002, 0));
            string str_36 = "1";
            db.AddTextToModelSpaceG(str_36, new Point3d(Bsae.X + 164.7523 , Bsae.Y + 14, 0));
            string str_37 = "1";
            db.AddTextToModelSpaceG(str_37, new Point3d(Bsae.X + 138.6241, Bsae.Y + 14, 0));
            string str_38 = "高压引线";
            db.AddTextToModelSpaceG(str_38, new Point3d(Bsae.X + 156.059, Bsae.Y + 7.1401, 0));
            
        }

        public static ObjectId AddRectToModelSpace(this Database db, Point2d point1, Point2d point2)
        {
            //声明多段线
            Polyline pLine = new Polyline();
            //计算矩形的四个顶点坐标
            Point2d p1 = new Point2d(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2d p2 = new Point2d(Math.Max(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2d p3 = new Point2d(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Point2d p4 = new Point2d(Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            //添加多段线顶点
            pLine.AddVertexAt(0, p1, 0, 0, 0);
            pLine.AddVertexAt(0, p2, 0, 0, 0);
            pLine.AddVertexAt(0, p3, 0, 0, 0);
            pLine.AddVertexAt(0, p4, 0, 0, 0);
            pLine.Closed = true;
            return db.AddEntityToModeSpace(pLine);

        }

        

    }
}
