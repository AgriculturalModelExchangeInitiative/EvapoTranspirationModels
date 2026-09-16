
# -*- coding: latin-1 -*-
# This file has been generated at Wed Sep 16 11:29:19 2026

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
                description='Python implementation of a simplified Penman-style PET model (from Sultani and Sinclair 2012) computing equilibrium evaporation EEQ = SRAD*(0.004876-0.004374*ALBEDO)*(TD+29) with TD = 0.6*TMAX+0.4*TMIN, PET adjusted by Tmax-dependent multipliers (including low-temperature and high-advection corrections) and intended to be combined with an exponential Beerâ\x80\x93Bouguerâ\x80\x93Lambert factor for fraction of uncovered soil.',
                category='Unclassified',
                nodemodule='potentialevapotranspiration',
                nodeclass='model_potentialevapotranspiration',
                inputs=[{'name': 'tmax', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'tmin', 'interface': IFloat(min=-60, max=60, step=1.000000), 'value': 0}, {'name': 'srad', 'interface': IFloat(min=0, max=120, step=1.000000), 'value': 0}, {'name': 'albedo', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 1.0}],
                outputs=[{'name': 'pet', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




pet = CompositeNodeFactory(name='pet',
                             description=('\n'
 '\n'
 '    SSM Evapotranspiration\n'
 '    -Version: 0.1  -Time step: 1\n'
 '    Authors: Thomas Sinclair, \n'
 '    Reference: None\n'
 '    Institution: CIRAD\n'
 '    ExtendedDescription: PotentialEvapotranspiration — simplified '
 'Penman-style PET (EEQ from srad, tmax, tmin with albedo and Tmax '
 'adjustments; cites Sultani and Sinclair 2012)\n'
 '    ShortDescription: Simplified Penman PET.\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'tmax'},
   {'interface': IFloat(min=-60, max=60, step=1.000000), 'name': 'tmin'},
   {'interface': IFloat(min=0, max=120, step=1.000000), 'name': 'srad'},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'albedo',
      'value': 1.0}],
                             outputs=[{'interface': IFloat, 'name': 'pet'}],
                             elt_factory={2: ('amei.ssm.pet', 'PotentialEvapotranspiration')},
                             elt_connections={  1404836643024: (2, 0, '__out__', 0),
   1404836643056: ('__in__', 0, 2, 0),
   1404836643088: ('__in__', 1, 2, 1),
   1404836643120: ('__in__', 2, 2, 2),
   1404836643152: ('__in__', 3, 2, 3)},
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




