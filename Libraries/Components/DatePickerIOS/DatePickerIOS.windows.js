/**
 * Copyright (c) 2015-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 *
 * @providesModule DatePickerIOS
 * @flow
 */
'use strict';

const DatePickerIOS = {
  async open(options: Object): Promise<Object> {
    return Promise.reject({
      message: 'DatePickerIOS is not supported on this platform.'
    });
  },
};

module.exports = DatePickerIOS;
