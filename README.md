# Desktop Weather

Currently, there is no decent weather forecasting program for the Windows desktop environment.  The Weather Channel does have one, but it's pretty large, a little flaky, and includes large advertisements.  This project is geared towards accomplishing the same goal but doing so in a smaller window with only the necessary information.

This program does use the Forecast API and does require an API key available from [https://developer.forecast.io/](https://developer.forecast.io/ "Forecast.IO").

[Download compiled versions here](https://kruug.org/draconemsoft/archive/desktopweather/).

## Screenshot

![App in action](https://kruug.org/draconemsoft/images/desktopweather/DesktopWeather_2_2_6.png)

## Installation

This is a "portable" program.  No installation required.

## Requirements

This program requires the .Net 4.5 run-time.  Download here: [http://www.microsoft.com/en-us/download/details.aspx?id=30653](http://www.microsoft.com/en-us/download/details.aspx?id=30653)

[NewtonSoft.JSON](http://www.newtonsoft.com/json) is required if building from source.

## Usage

Currently, there is a constant available in the code for the API key.  You will have to get your own key if you build from source, but the pre-compiled binary has a key already enabled.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History/Changelog

 - 2015-02-12: Stable build, first commit (v 0.1)
 - 2015-02-17: Stable build, added manual refresh option (v 0.2)
 - 2015-02-18: Stable build, added metric/imperial choices, started work on timed refresh (v 0.5)
 - 2015-02-19: Stable build, changed `Imperial` to `US units`, changed WU logo to adhere to their specifications, timed refresh now working (v 0.8)
 - 2015-03-02: Stable build, tweaked UI, separated current conditions class from forecast class, added About window (v 0.8.5)
 - 2015-05-20: Added IP to Latitude/Longitude class/function, added some variables to start moving to new weather API (No new release)
 - 2015-05-31: Converted to C#, location-based forecast fully working, changed API and all related documentation (v 0.9.0)
 - 2015-06-06: 3-Day forecast auto-updates properly, option to view current-only weather in a small on-top window in bottom right corner of monitor, getting a few things buttoned up before v1.0 release
 - 2015-06-07: Officially releasing v1.0
 - 2015-12-17: Release of v2.0.  Includes forecast and current details, changed icons to [Climacons](http://adamwhitcroft.com/climacons/).  Started on implementing weather alert system
 - 2016-01-11: Added button and pop-up form for displaying weather alerts. (v2.1)
 - 2016-01-12: Fixed issue with pop-ups disposing early. (v2.2)
 - 2016-02-08: Fixed encoding error.  Strings are now UTF32 to allow for full range of characters from API.
 - 2016-04-13: v2.2.6 Added alert button functionality to "Currently" option to be the same as the 3-day forecast window.

## Future/To-Do

### Additional wish-list
 - Add option for more days for forecasting (currently today + 2 more, maybe expand to 5 or 10 days)(Mostly done, looking to add today + 6 more)

## License

The MIT License (MIT)

Copyright (c) 2016 Viktor Kruug

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
