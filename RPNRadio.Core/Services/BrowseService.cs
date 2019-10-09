using MediaManager.Library;
using RPNRadio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPNRadio.Core.Services
{
    public class BrowseService : IBrowseService
    {

        public Task<IList<IMediaItem>> GetMedia()
        {
            List<Station> stations = new List<Station>()
            {
                new Station("DZRL Batac", 8956),
                new Station("DZBS Baguio", 8169),
                new Station("DZKI Iriga", 8996),
                new Station("DYKB Bacolod", 8251),
                new Station("DYKC Cebu", 8113),
                new Station("DXKO Cagayan de Oro", 8960),
                new Station("DXKT Davao", 9056),
                new Station("DXKD Dipolog", 8481),
                new Station("DXDX General Santos", 8952),
                new Station("DXKS Surigao", 8448),
                new Station("DXXX Zamboanga", 8452),
                //new Station("Test Station", 9079),
            };

            IList<IMediaItem> items = new List<IMediaItem>();

            foreach (var s in stations)
            {
                var mediaItem = new MediaItem(s.Url)
                {
                    Title = s.Name,
                };

                items.Add(mediaItem);
            }

            return Task.FromResult(items);

        }
    }
}