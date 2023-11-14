using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Geometry;

namespace _01fastnote
{
    public static class fast_note
    {
        [CommandMethod("BBT")]
        public static void BBT()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;

            PromptPointResult ppr = ed.GetPoint("\n 请选择一个点:");
            double radius = 5;
            if(ppr.Status == PromptStatus.OK)
            {
                Point3d p1 = ppr.Value;
                
                ppr = ed.GetPoint("\n 请选择二个点:");

                if(ppr.Status == PromptStatus.OK)
                {
                    Point3d p2 = ppr.Value;
                    PromptIntegerOptions options = new PromptIntegerOptions("\n 请输入放大倍数：");
                    PromptIntegerResult result = ed.GetInteger(options);
                    switch (result.Status)
                    {
                        case PromptStatus.OK:
                            short multiple;
                            multiple = (short) result.Value;
                            db.AddLineToModeSpace(p1, p2, radius, multiple); // 已知起点和终点
                            db.AddCircleModeSpace(p2, radius, multiple); // 圆心半径画圆
                            db.AddTextToModelSpace(p2, multiple);
                            break;

                        case PromptStatus.Cancel:
                            ed.WriteMessage("\n用户取消了输入");
                            break;
                    }
                }
            }
        }

        public static ObjectId AddEntityToModeSpace(this Database db, Entity ent)
        {
            // 声明ObjectId 用于返回
            ObjectId entId = ObjectId.Null;
            // 开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // 打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                // 打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                // 添加图形到块表记录
                entId = btr.AppendEntity(ent);
                // 更新数据信息
                trans.AddNewlyCreatedDBObject(ent, true);
                // 提交事务
                trans.Commit();
            }
            return entId;
        }

        // 为什么要声明 static ，一个声明了其他的也得跟着声明

        public static ObjectId AddCircleModeSpace(this Database db, Point3d center, double radius , Int16 multiple)
        {
            return db.AddEntityToModeSpace(new Circle((center), new Vector3d(0, 0, 1), radius * multiple));
        }

        public static ObjectId AddTextToModelSpace(this Database db , Point3d startpoint , Int16 multiple)
        {
            DBText text0 = new DBText();
            text0.Position = startpoint;
            text0.TextString = "1";
            text0.Height = 4 * multiple;
            
            text0.HorizontalMode = TextHorizontalMode.TextCenter;
            text0.VerticalMode = TextVerticalMode.TextVerticalMid;
            text0.AlignmentPoint = startpoint;

            return db.AddEntityToModeSpace(text0);
        }

        public static ObjectId AddLineToModeSpace(this Database db, Point3d startPoint, Point3d endPoint , double radius, Int16 multiple)
        {
            double interval_x = Math.Pow(endPoint.X - startPoint.X, 2);
            double interval_y = Math.Pow(endPoint.Y - startPoint.Y, 2);
            double Distance = Math.Sqrt(interval_x + interval_y) - radius * multiple;
        
            double angle = Math.Atan2((endPoint.Y - startPoint.Y), (endPoint.X - startPoint.X));
            // double theta = angle * 180 / Math.PI ;

            double X_new = startPoint.X + Distance * Math.Cos(angle);
            double Y_new = startPoint.Y + Distance * Math.Sin(angle);

            Point3d midpoint = new Point3d(X_new, Y_new, 0);

            return db.AddEntityToModeSpace(new Line(startPoint, midpoint));
        }

    }
}
