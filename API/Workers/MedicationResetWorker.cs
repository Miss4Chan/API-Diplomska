using System;

namespace API.Workers;

using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Interfaces;

public class MedicationResetWorker(IMedicationRepository medicationRepository) : BackgroundService
{
    private readonly IMedicationRepository _medicationRepository = medicationRepository;
    private readonly TimeSpan _runTime = TimeSpan.FromHours(24); // Interval of 24 hours
    private Timer _timer = null!;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Calculate the time until midnight
        var now = DateTime.Now;
        var midnight = DateTime.Today.AddDays(1).AddHours(0); // Next midnight
        var timeToMidnight = midnight - now;

        // Run at midnight and then every 24 hours
        _timer = new Timer(DoWork, null, timeToMidnight, _runTime);

        return Task.CompletedTask;
    }

    private async void DoWork(object state)
    {
        Console.WriteLine("MedicationResetWorker running at: {0}", DateTime.Now);
        var todayIndex = (int)DateTime.Today.DayOfWeek;

        var medications = await _medicationRepository.GetMedicationsForDayAsync(todayIndex);

        foreach (var medication in medications)
        {
            foreach (var intake in medication.MedicationIntakes)
            {
                if (!intake.Taken && intake.Timestamp.Date == DateTime.Today)
                {
                    // Mark as not taken if not taken by end of the day
                    intake.Taken = false;
                    intake.Timestamp = DateTime.Now; // Mark with current timestamp
                }
            }
        }

        // Save changes to the repository
        await _medicationRepository.SaveChanges();
    }

    public override void Dispose()
    {
        _timer?.Dispose();
        base.Dispose();
    }
}
