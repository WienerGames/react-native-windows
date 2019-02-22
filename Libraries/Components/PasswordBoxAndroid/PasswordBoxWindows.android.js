/**
 * Copyright (c) 2015-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 *
 * Portions copyright for react-native-windows:
 *
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License.
 *
 * @providesModule PasswordBoxAndroid
 * @flow
 * @format
 */
'use strict';

const PasswordBoxAndroid = {
  async open(options: Object): Promise<Object> {
    return Promise.reject({
      message: 'PasswordBoxAndroid is not supported on this platform.'
    });
  },
};

module.exports = PasswordBoxAndroid;