/**
 * @providesModule CalendarDatePickerWindows
 * @flow
*/
'use strict';

const CalendarDatePickerWindows = {
  async open(options: Object): Promise<Object> {
    return Promise.reject({
      message: 'CalendarDatePickerIOS is not supported on this platform.'
    });
  },
};

module.exports = CalendarDatePickerWindows;