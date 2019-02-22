/**
 * Copyright (c) 2015-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 *
 * @providesModule DatePickerWindows
 * @flow
 */
'use strict';

const DatePickerWindows = {
    async open(options: Object): Promise<Object> {
        return Promise.reject({
            message: 'DatePickerWindows is not supported on this platform.'
        });
    },
};

module.exports = DatePickerWindows;
