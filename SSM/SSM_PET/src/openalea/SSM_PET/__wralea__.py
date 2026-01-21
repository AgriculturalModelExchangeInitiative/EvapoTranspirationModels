
# -*- coding: latin-1 -*-
# This file has been generated at Wed Jan 21 15:31:22 2026

from openalea.core import *


__name__ = 'amei.ssm.pet'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['pet']


__all__ = ['potentialevapotranspiration_model_potentialevapotranspiration', 'pet']



potentialevapotranspiration_model_potentialevapotranspiration = Factory(name='PotentialEvapotranspiration',
                authors='AMEI Consortium (wralea authors)',
                description='Computes daily potential evapotranspiration (PET, mm d-1) following Soltani and Sinclair (2012) using an equilibrium evaporation (EEQ) term adjusted by temperature-dependent multipliers. Average daytime temperature is TD = 0.6Ã\x82Â·Tmax + 0.4Ã\x82Â·Tmin. The surface albedo blends crop and soil albedos weighted by the fraction of surface energy reaching soil, exp(-KETÃ\x82Â·ETLAI): ALBEDO = CALBÃ\x82Â·(1 - exp(-KETÃ\x82Â·ETLAI)) + SALBÃ\x82Â·exp(-KETÃ\x82Â·ETLAI). EEQ is then EEQ = SRADÃ\x82Â·(0.004876 - 0.004374Ã\x82Â·ALBEDO)Ã\x82Â·(TD + 29). PET is derived from EEQ with three regimes: PET = 1.1Ã\x82Â·EEQ for 5 < Tmax < 34; PET = EEQÃ\x82Â·((Tmax - 34)Ã\x82Â·0.05 + 1.1) for Tmax Ã¢\x89Â¥ 34 (advection); PET = EEQÃ\x82Â·0.01Ã\x82Â·exp(0.18Ã\x82Â·(Tmax + 20)) for Tmax Ã¢\x89Â¤ 5 (cold/frozen conditions). The uncovered-soil fraction follows the BeerÃ¢\x80\x93BouguerÃ¢\x80\x93Lambert law via ETLAI and KET. Methodology relates to PriestleyÃ¢\x80\x93Taylor (1972) and the modifications summarized by Ritchie (1998) as presented in Soltani and Sinclair (2012).',
                category='Unclassified',
                nodemodule='potentialevapotranspiration',
                nodeclass='model_potentialevapotranspiration',
                inputs=[{'name': 'tmax', 'interface': IFloat, 'value': 0}, {'name': 'tmin', 'interface': IFloat, 'value': 0}, {'name': 'srad', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'etlai', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'ket', 'interface': IFloat(min=0, max=2, step=1.000000), 'value': 0.5}, {'name': 'calb', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.23}, {'name': 'salb', 'interface': IFloat(min=0, max=1, step=1.000000), 'value': 0.13}],
                outputs=[{'name': 'pet', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




pet = CompositeNodeFactory(name='pet',
                             description=('\n'
 '\n'
 '    PET\n'
 '    -Version: 0.1  -Time step: 1\n'
 '    Authors: -\n'
 '    Reference: None\n'
 '    Institution: -\n'
 '    ExtendedDescription: Computes daily potential evapotranspiration (PET, '
 'mm d-1) following Soltani & Sinclair (2012) using an equilibrium evaporation '
 '(EEQ) term adjusted by temperature-dependent multipliers. Average daytime '
 'temperature is TD = 0.6·Tmax + 0.4·Tmin. The surface albedo blends crop and '
 'soil albedos weighted by the fraction of surface energy reaching soil, '
 'exp(−KET·ETLAI): ALBEDO = CALB·(1 − exp(−KET·ETLAI)) + SALB·exp(−KET·ETLAI). '
 'EEQ is then EEQ = SRAD·(0.004876 − 0.004374·ALBEDO)·(TD + 29). PET is '
 'derived from EEQ with three regimes: PET = 1.1·EEQ for 5 < Tmax < 34; PET = '
 'EEQ·((Tmax − 34)·0.05 + 1.1) for Tmax ≥ 34 (advection); PET = '
 'EEQ·0.01·exp(0.18·(Tmax + 20)) for Tmax ≤ 5 (cold/frozen conditions). The '
 'uncovered-soil fraction follows the Beer–Bouguer–Lambert law via ETLAI and '
 'KET. Methodology relates to Priestley–Taylor (1972) and the modifications '
 'summarized by Ritchie (1998) as presented in Soltani & Sinclair (2012).\n'
 '    ShortDescription: PET component using EEQ with Beer–Lambert canopy '
 'attenuation and temperature-based modifiers per Soltani & Sinclair (2012).\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat, 'name': 'tmax'},
   {'interface': IFloat, 'name': 'tmin'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'srad'},
   {'interface': IFloat(min=0, max=16777216, step=1.000000), 'name': 'etlai'},
   {  'interface': IFloat(min=0, max=2, step=1.000000),
      'name': 'ket',
      'value': 0.5},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'calb',
      'value': 0.23},
   {  'interface': IFloat(min=0, max=1, step=1.000000),
      'name': 'salb',
      'value': 0.13}],
                             outputs=[{'interface': IFloat, 'name': 'pet'}],
                             elt_factory={2: ('amei.ssm.pet', 'PotentialEvapotranspiration')},
                             elt_connections={  4302555280: (2, 0, '__out__', 0),
   4302555312: ('__in__', 0, 2, 0),
   4302555344: ('__in__', 1, 2, 1),
   4302555376: ('__in__', 2, 2, 2),
   4302555408: ('__in__', 3, 2, 3),
   4302555440: ('__in__', 4, 2, 4),
   4302555472: ('__in__', 5, 2, 5),
   4302555504: ('__in__', 6, 2, 6)},
                             elt_data={  2: {  'block': False,
         'caption': 'PotentialEvapotranspiration',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0,
         'posy': 250.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   '__in__': {  'block': False,
                'caption': 'In',
                'delay': 0,
                'hide': True,
                'id': 0,
                'lazy': True,
                'port_hide_changed': set(),
                'posx': 250.0,
                'posy': 0,
                'priority': 0,
                'use_user_color': True,
                'user_application': None,
                'user_color': None},
   '__out__': {  'block': False,
                 'caption': 'Out',
                 'delay': 0,
                 'hide': True,
                 'id': 1,
                 'lazy': True,
                 'port_hide_changed': set(),
                 'posx': 250.0,
                 'posy': 500,
                 'priority': 0,
                 'use_user_color': True,
                 'user_application': None,
                 'user_color': None}},
                             elt_value={2: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [0, 250.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




