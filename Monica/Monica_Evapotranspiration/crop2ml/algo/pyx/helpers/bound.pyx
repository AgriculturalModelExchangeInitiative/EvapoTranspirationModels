# This Source Code Form is subject to the terms of the Mozilla Public
# License, v. 2.0. If a copy of the MPL was not distributed with this
# file, You can obtain one at https://mozilla.org/MPL/2.0/.

def bound(float lower, float value, float upper):
    if value < lower:
        return lower
    if value > upper:
        return upper
    return value
