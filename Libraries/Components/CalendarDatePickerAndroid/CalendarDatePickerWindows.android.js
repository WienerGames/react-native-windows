/**
 * @providesModule CalendarDatePickerAndroid
 * @flow
*/
'use strict';

const CalendarDatePickerAndroid = {
  async open(options: Object): Promise<Object> {
    return Promise.reject({
      message: 'CalendarDatePickerAndroid is not supported on this platform.'
    });
  },
};

module.exports = CalendarDatePickerAndroid;