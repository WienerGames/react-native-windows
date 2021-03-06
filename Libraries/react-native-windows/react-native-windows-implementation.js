/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License.
 *
 * @providesModule react-native-windows-implementation
 * @flow
 */
'use strict';

var ReactWindows = {
  // Components
  get DateFlyoutWindows() { return require('DateFlyoutWindows'); },
  get DatePickerWindows() { return require('DatePickerWindows'); },
  get TimePickerWindows() { return require('TimePickerWindows'); },
  get CalendarDatePickerWindows() { return require('CalendarDatePickerWindows'); },
  get FlipViewWindows() { return require('FlipViewWindows'); },
  get PasswordBoxWindows() { return require('PasswordBoxWindows'); },
  get ProgressBarWindows() { return require('ProgressBarWindows'); },
  get ProgressRingWindows() { return require('ProgressRingWindows'); },
  get SplitViewWindows() { return require('SplitViewWindows'); },

  get createFocusableComponent() { return require('FocusableWindows'); },
};

module.exports = ReactWindows;
