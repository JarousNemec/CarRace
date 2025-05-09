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
    }


    private void mainloop_Tick(object sender, EventArgs e)
    {
        _speed = _tbSpeedControl.Value;
        _lblSpeed.Text = _speed.ToString()+"x";
        
        SetupPoint();
        CountDrivenDistance();
        Invalidate();
    }

    private Point _currentPoint;
    private Point _nextPoint;
    private int _index = 0;
    private int _speed = 1;

    private void SetupPoint()
    {
        var track = _ovalModel.GetTrack();
        _currentPoint = track[_index];
        if (_index + _speed >= track.Count)
        {
            _index = _index+_speed-track.Count ;
        }
        else
        {
            _index += _speed;
        }
        _nextPoint = track[_index];
    }

    private void CountDrivenDistance()
    {
        var step = new Vector2(_nextPoint.X - _currentPoint.X, _nextPoint.Y - _currentPoint.Y);
        _distance += Math.Round(step.Length(), 0);
        _lblAngle.Text = $"Driven distance: {_distance}";
    }


    private const int CAR_SIZE = 20;
    private double _distance = 0;

    private void Oval_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.DrawImage(_ovalModel.GetTrackBitmap(), new Point(0, 0));
        if (_currentPoint == null)
            return;

        g.FillPie(Brushes.Green, _currentPoint.X - CAR_SIZE / 2, _currentPoint.Y - CAR_SIZE / 2, CAR_SIZE,
            CAR_SIZE, 0, 360);
    }

    private bool _run = false;

    private void _btnToggleRun_MouseDown(object sender, MouseEventArgs e)
    {
        if (_run)
        {
            _run = false;
            _btnToggleRun.Text = "Start";
            mainloop.Stop();
        }
        else
        {
            _run = true;
            _btnToggleRun.Text = "Stop";
            mainloop.Start();
        }
    }
}