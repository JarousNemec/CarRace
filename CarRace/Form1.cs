using System.Numerics;
using CarRace.Models;
using CarRace.Utils;

namespace CarRace;

public partial class Form1 : Form
{
    private readonly OvalModel _ovalModel;

    public Form1()
    {
        InitializeComponent();
        DoubleBuffered = true;
        _ovalModel = new OvalModel();
    }

    private void Oval_Load(object sender, EventArgs e)
    {
        //prepare data
        mainloop.Interval = 10;
        mainloop.Start();
    }

    private TrackPart _currentPoint;
    private TrackPart _nextPoint;
    private int index = 0;

    private void mainloop_Tick(object sender, EventArgs e)
    {
        var track = _ovalModel.GetTrack();
        _currentPoint = track[index];
        if (index + 1 == track.Count)
            index = -1;


        _nextPoint = track[index + 1];

        Invalidate();
        index++;
    }


    private const int CAR_SIZE = 20;

    private void Oval_Paint(object sender, PaintEventArgs e)
    {
        if (_currentPoint == null)
            return;
        // var defaultDirection = new Vector2(_ovalModel.VectorPoint.X - _ovalModel.StartPoint.X, -(_ovalModel.VectorPoint.Y - _ovalModel.StartPoint.Y));
        // var direction = new Vector2(_nextPoint.Point.X - _currentPoint.Point.X, -(_nextPoint.Point.Y - _currentPoint.Point.Y));
        // double scalar = Vector2.Dot(defaultDirection, direction);
        // double lengths = defaultDirection.Length() * direction.Length();
        // var a = Math.Round(scalar / lengths, 3);
        // var angle = Math.Acos(a)*(180.0/Math.PI);
        // _lblAngle.Text = "Angle: " + angle.ToString();
        
        var g = e.Graphics;
        g.DrawImage(_ovalModel.GetTrackBitmap(), new Point(0, 0));
        // var xTranslate = _currentPoint.Point.X + CAR_WIDTH / 2;
        // var yTranslate = _currentPoint.Point.Y + CAR_HEIGHT / 2;
        // g.TranslateTransform(xTranslate, yTranslate);
        // g.RotateTransform((float)angle);
        // g.TranslateTransform(-xTranslate, -yTranslate);

        g.FillPie(Brushes.Green, _currentPoint.Point.X-CAR_SIZE/2, _currentPoint.Point.Y-CAR_SIZE/2, CAR_SIZE, CAR_SIZE, 0, 360);
        g.ResetTransform();
    }
}