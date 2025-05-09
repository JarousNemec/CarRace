using System.Numerics;
using CarRace.Utils;

namespace CarRace.Models;

public class OvalModel
{
    private readonly Graphics _g;
    private readonly Bitmap _map;
    private Pen _trackPen = new Pen(Color.Red, 1);
    private readonly List<Point> _track;
    public Point StartPoint { get; set; } = new Point(190, 100);
    public Point VectorPoint { get; set; } = new Point(195, 100);

    public OvalModel()
    {
        _map = new Bitmap(1000, 1000);
        _g = Graphics.FromImage(_map);
        DrawBasicTrack();
        var pixels = GraphicsUtils.GetBitmapAsColor(_map);
        var trackPoints = ReadOnlyTrackPoints(pixels, _trackPen.Color);
        _track = AnalyzeTrack(trackPoints,StartPoint , VectorPoint);
    }

    private void DrawBasicTrack()
    {
        _g.DrawArc(_trackPen, 100, 100, 200, 200, -90, -180);
        _g.DrawLine(_trackPen, 200, 100, 400, 100);
        _g.DrawLine(_trackPen, 200, 300, 400, 300);
        _g.DrawArc(_trackPen, 300, 100, 200, 200, -90, 90);
        _g.DrawLine(_trackPen, 500, 200, 500, 500);
        _g.DrawArc(_trackPen, 400, 500, 200, 200, -90, 270);
        _g.DrawLine(_trackPen, 400, 600, 400, 300);
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

    private List<Point> AnalyzeTrack(bool[,] trackPoints, Point startPoint, Point vectorPoint)
    {
        var track = new List<Point>();
        track.Add(startPoint);

        Point currentPoint = startPoint;
        Vector2 currentDirection = new Vector2(vectorPoint.X - startPoint.X, -(vectorPoint.Y - startPoint.Y));
        while (true)
        {
            var searchedPoints = GetPointsAroundPoint3(currentPoint);
            var trackSigns = new List<Point>();
            IdentifyPotentialNextTrackPoints(trackPoints, searchedPoints, trackSigns);

            Double smallestAngle = 360;
            Point nextPoint = currentPoint;
            Vector2 nextDirection = currentDirection;
            foreach (var point in trackSigns)
            {
                var direction = CalculateAngleBetweenVectors(point, currentPoint, currentDirection, out var angle);

                if (angle < smallestAngle)
                {
                    smallestAngle = (float)angle;
                    nextPoint = point;
                    nextDirection = direction;
                }
            }
            currentPoint = nextPoint;
            currentDirection = nextDirection;
            if (track.Any(x => x.X == nextPoint.X && x.Y == nextPoint.Y))
                break;
            track.Add(currentPoint);
            
        }

        return track;
    }

    private static Vector2 CalculateAngleBetweenVectors(Point point, Point currentPoint, Vector2 currentDirection,
        out double angle)
    {
        var direction = new Vector2(point.X - currentPoint.X, -(point.Y - currentPoint.Y));
        double scalar = Vector2.Dot(currentDirection, direction);
        double lengths = currentDirection.Length() * direction.Length();
        var a = Math.Round(scalar / lengths, 3);
        angle = Math.Acos(a)*(180.0/Math.PI);
        return direction;
    }

    private static void IdentifyPotentialNextTrackPoints(bool[,] trackPoints, List<Point> searchedPoints, List<Point> trackSigns)
    {
        foreach (var point in searchedPoints)
        {
            if (trackPoints[point.X, point.Y])
            {
                trackSigns.Add(point);
            }
        }
    }

    public Bitmap GetTrackBitmap()
    {
        return _map;
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

    public List<Point> GetTrack()
    {
        return _track;
    }
}