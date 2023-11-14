using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02快速创建图框
{
    public static class PromptTools
    {


        /// <summary>
        /// 获取点
        /// </summary>
        /// <param name="ed">命令行对象</param>
        /// <param name="promptStr">提示信息</param>
        /// <returns> PromptPointResult</returns>
        public static PromptPointResult GetPoint2(this Editor ed, string promptStr)
        {
            // 声明一个获取点的提示类
            PromptPointOptions ppo = new PromptPointOptions(promptStr);
            // 使回车和空格键有效
            ppo.AllowNone = true;
            return ed.GetPoint(ppo);
        }


        /// <summary>
        /// 获取点或关键字
        /// </summary>
        /// <param name="ed">命令行</param>
        /// <param name="promptStr">提示信息</param>
        /// <param name="pointBase">基准点</param>
        /// <param name="keyWord">关键字</param>
        /// <returns>PromptPointResult</returns>
        public static PromptPointResult GetPoint(this Editor ed, string promptStr, params string[] keyWord)
        {

            // 声明一个获取点的提示类
            PromptPointOptions ppo = new PromptPointOptions(promptStr);
            // 使回车和空格键有效
            ppo.AllowNone = true;
            // 添加字符是的相应的字符按键有效
            for (int i = 0; i < keyWord.Length; i++)
            {
                ppo.Keywords.Add(keyWord[i]);
            }
            // 取消系统自动关键字显示
            ppo.AppendKeywordsToMessage = false;
            // 设置基准点
            //ppo.BasePoint = pointBase;
            //ppo.UseBasePoint = true;
            return ed.GetPoint(ppo);
        }

        public static void AddTextToModelSpace(this Database db, String str , Point3d location )
        {
            Color blue = Color.FromRgb(0, 255, 255);
            Color red = Color.FromRgb(255, 0, 0);
            Color green = Color.FromRgb(0, 255, 0);
            Color white = Color.FromRgb(255, 255, 255);

            DBText text = new DBText();
            text.Position = location;
            text.TextString = str;
            text.Color = blue;
            text.HorizontalMode = TextHorizontalMode.TextLeft;
            text.WidthFactor = 0.9;
            text.Height = 3;

            db.AddEntityToModeSpace(text);
        }

        public static void AddTextToModelSpaceG(this Database db, String str, Point3d location)
        {
            Color blue = Color.FromRgb(0, 255, 255);
            Color red = Color.FromRgb(255, 0, 0);
            Color green = Color.FromRgb(0, 255, 0);
            Color white = Color.FromRgb(255, 255, 255);

            DBText text = new DBText();
            text.Position = location;
            text.TextString = str;
            text.Color = green;
            text.HorizontalMode = TextHorizontalMode.TextLeft;
            text.WidthFactor = 0.9;
            text.Height = 4;

            db.AddEntityToModeSpace(text);
        }

        public static void AddTextBar(this Database db , Point3d Bsaepoint)
        {
           // Database db = HostApplicationServices.WorkingDatabase;
            Color blue = Color.FromRgb(0, 255, 255);
            Color red = Color.FromRgb(255, 0, 0);
            Color green = Color.FromRgb(0, 255, 0);
            Color white = Color.FromRgb(255, 255, 255);
            //人工设置基准点
            Point3d Bsae = new Point3d(Bsaepoint.X, Bsaepoint.Y, 0);

            // 第一部分的程序(线框)
            // 横线
            Line[] L_one_1 = new Line[5];
            Point3d[] P_one_1 = new Point3d[5];
            Point3d[] P_one_2 = new Point3d[5];
            for (int i = 0; i < L_one_1.Length; i++)
            {
                P_one_1[i] = new Point3d(Bsae.X, Bsae.Y + 5 + 5 * i, 0);
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
            double[] I_two_1 = new double[6] { 0, 8.5, 14, 31, 46, 63 };
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
            double[] I_three_1 = new double[7] { 0, 8, 48, 92, 100, 138, 160 };
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
            double[] I_five_1 = new double[4] { 124, 138, 152, 166 };
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
            db.AddTextToModelSpace(str_20, new Point3d(Bsae.X + 127.395, Bsae.Y + 38.7426, 0));
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
            db.AddTextToModelSpaceG(str_36, new Point3d(Bsae.X + 164.7523, Bsae.Y + 14, 0));
            string str_37 = "1";
            db.AddTextToModelSpaceG(str_37, new Point3d(Bsae.X + 138.6241, Bsae.Y + 14, 0));
            string str_38 = "高压引线";
            db.AddTextToModelSpaceG(str_38, new Point3d(Bsae.X + 156.059, Bsae.Y + 7.1401, 0));

        }

    }
}
