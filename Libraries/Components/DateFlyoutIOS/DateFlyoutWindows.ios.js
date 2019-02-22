/**
 * @providesModule DateFlyoutWindows
 * @flow
 */
'use strict';

const DateFlyoutWindows = {
    async open(options: Object): Promise<Object> {
        return Promise.reject({
            message: 'DateFlyoutIOS is not supported on this platform.'
        });
    },
};

module.exports = DateFlyoutWindows;