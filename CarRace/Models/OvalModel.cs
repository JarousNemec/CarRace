using System.Drawing.Drawing2D;
using System.Numerics;
using CarRace.Utils;

namespace CarRace.Models;

public class OvalModel
{
    private readonly Graphics g;
    private readonly Bitmap map;
    Pen trackPen = new Pen(Color.Red, 1);
    private readonly List<TrackPart> track;
    public Point StartPoint { get; set; } = new Point(190, 100);
    public Point VectorPoint { get; set; } = new Point(195, 100);

    public OvalModel()
    {
        map = new Bitmap(1000, 1000);
        g = Graphics.FromImage(map);
        DrawBasicTrack();
        var pixels = GraphicsUtils.GetBitmapAsColor(map);
        var trackPoints = ReadOnlyTrackPoints(pixels, trackPen.Color);
        track = AnalyzeTrack(trackPoints,StartPoint , VectorPoint);
        
        // g.DrawLines(Pens.Blue, track.ToArray());
        
        // g.FillRectangle(Brushes.Green, 100,100,20,10);
    }

    private void DrawBasicTrack()
    {
        g.DrawArc(trackPen, 100, 100, 200, 200, -90, -180);
        g.DrawLine(trackPen, 200, 100, 400, 100);
        g.DrawLine(trackPen, 200, 300, 400, 300);
        g.DrawArc(trackPen, 300, 100, 200, 200, -90, 90);
        g.DrawLine(trackPen, 500, 200, 500, 500);
        g.DrawArc(trackPen, 400, 500, 200, 200, -90, 270);
        g.DrawLine(trackPen, 400, 600, 400, 300);
    }

    private bool[,] ReadOnlyTrackPoints(Color[,] pixels, Color trackColor)
    {
        var points = new bool[pixels.GetLength(0), pixels.GetLength(1)];

        for (int y = 0; y < pixels.GetLength(1); y++)
        for (int x = 0; x < pixels.GetLength(0); x++)
        {
            // Console.WriteLine("x: " + x + ", y: " + y);
            if (GraphicsUtils.IsSameColor(pixels[x, y], trackColor))
            {
                points[x, y] = true;
            }
        }

        return points;
    }

    private List<TrackPart> AnalyzeTrack(bool[,] trackPoints, Point startPoint, Point vectorPoint)
    {
        var track = new List<TrackPart>();
        track.Add(new TrackPart(){Point = startPoint, Angle = 0});

        Point currentPoint = startPoint;
        Vector2 currentDirection = new Vector2(vectorPoint.X - startPoint.X, -(vectorPoint.Y - startPoint.Y));
        double currentAngle = 0;
        while (true)
        {
            var searchedPoints = GetPointsAroundPoint3(currentPoint);
            var trackSigns = new List<Point>();
            foreach (var point in searchedPoints)
            {
                if (trackPoints[point.X, point.Y])
                {
                    trackSigns.Add(point);
                }
            }

            Double smallestAngle = 360;
            Point nextPoint = currentPoint;
            Vector2 nextDirection = currentDirection;
            foreach (var point in trackSigns)
            {
                var direction = new Vector2(point.X - currentPoint.X, -(point.Y - currentPoint.Y));
                double scalar = Vector2.Dot(currentDirection, direction);
                double lengths = currentDirection.Length() * direction.Length();
                var a = Math.Round(scalar / lengths, 3);
                var angle = Math.Acos(a)*(180.0/Math.PI);

                if (angle < smallestAngle)
                {
                    smallestAngle = (float)angle;
                    nextPoint = point;
                    nextDirection = direction;
                }
            }
            currentPoint = nextPoint;
            currentDirection = nextDirection;
            currentAngle += smallestAngle;
            if (track.Any(x => x.Point.X == nextPoint.X && x.Point.Y == nextPoint.Y))
                break;
            track.Add(new TrackPart(){Point = currentPoint, Angle = currentAngle});
            
        }

        return track.ToList();
    }

    public Bitmap GetTrackBitmap()
    {
        return map;
    }

    private List<Point> GetPointsAroundPoint3(Point point)
    {
        List<Point> points = new List<Point>();
        //*
        //*__x
        //*
        points.Add(new Point(point.X - 2, point.Y - 1));
        points.Add(new Point(point.X - 2, point.Y));
        points.Add(new Point(point.X - 2, point.Y + 1));

        //_*
        points.Add(new Point(point.X - 2, point.Y + 2));

        //__***
        points.Add(new Point(point.X - 1, point.Y + 2));
        points.Add(new Point(point.X, point.Y + 2));
        points.Add(new Point(point.X + 1, point.Y + 2));

        //_-___*
        points.Add(new Point(point.X + 2, point.Y + 2));

        //-_____*
        //-__x__*
        //-__x__*
        points.Add(new Point(point.X + 2, point.Y - 1));
        points.Add(new Point(point.X + 2, point.Y));
        points.Add(new Point(point.X + 2, point.Y + 1));

        //_-___*
        points.Add(new Point(point.X + 2, point.Y - 2));

        //__***
        points.Add(new Point(point.X - 1, point.Y - 2));
        points.Add(new Point(point.X, point.Y - 2));
        points.Add(new Point(point.X + 1, point.Y - 2));

        //_*
        points.Add(new Point(point.X - 2, point.Y - 2));

        return points;
    }

    public List<TrackPart> GetTrack()
    {
        return track;
    }
}