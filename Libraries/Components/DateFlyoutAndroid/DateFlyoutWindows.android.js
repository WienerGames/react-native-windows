/**
 * @providesModule DateFlyoutWindows
 * @flow
 */
'use strict';

const DateFlyoutWindows = {
    async open(options: Object): Promise<Object> {
        return Promise.reject({
            message: 'DateFlyoutAndroid is not supported on this platform.'
        });
    },
};

module.exports = DateFlyoutWindows;