
# -*- coding: latin-1 -*-
# This file has been generated at Wed Sep 16 11:27:44 2026

from openalea.core import *


__name__ = 'amei.siriusquality_energybalance.potentialet-pt'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['PotentialET_PT']


__all__ = ['priestlytaylor_model_priestlytaylor']



priestlytaylor_model_priestlytaylor = Factory(name='PriestlyTaylor',
                authors='AMEI Consortium (wralea authors)',
                description='Calculate Energy Balance',
                category='',
                nodemodule='priestlytaylor',
                nodeclass='model_priestlytaylor',
                inputs=[{'name': 'lambdaV', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 2.454}, {'name': 'netRadiation', 'interface': IFloat(min=0, max=5000, step=1.000000), 'value': 1.566}, {'name': 'psychrometricConstant', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.66}, {'name': 'Alpha', 'interface': IFloat(min=0, max=100, step=1.000000), 'value': 1.5}, {'name': 'solarRadiation', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 3.0}, {'name': 'hslope', 'interface': IFloat(min=0, max=1000, step=1.000000), 'value': 0.584}, {'name': 'ih', 'interface': IInt(min=-999, max=24, step=1), 'value': -999}],
                outputs=[{'name': 'evapoTranspirationPriestlyTaylor', 'interface': IFloat(min=0, max=10000, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




