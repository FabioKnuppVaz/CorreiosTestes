﻿#!/bin/bash

PLATFORM=linux64 # Change this line if You're using other platform
VERSION=$(curl http://chromedriver.storage.googleapis.com/LATEST_RELEASE)
curl http://chromedriver.storage.googleapis.com/$VERSION/chromedriver_$PLATFORM.zip -LOk
unzip chromedriver_*
rm chromedriver_*