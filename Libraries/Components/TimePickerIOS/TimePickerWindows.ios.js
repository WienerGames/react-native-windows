/**
 * Copyright (c) 2015-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 *
 * @providesModule TimePickerIOS
 * @flow
 */
'use strict';

const TimePickerIOS = {
  async open(options: Object): Promise<Object> {
    return Promise.reject({
      message: 'TimePickerIOS is not supported on this platform.'
    });
  },
};

module.exports = TimePickerIOS;
