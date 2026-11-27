
# -*- coding: latin-1 -*-
# This file has been generated at Fri Nov 27 11:36:15 2026

from openalea.core import *


__name__ = 'amei.monica_evapotranspiration.ameipotet'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['AMEIPotET']


__all__ = ['saturationvaporpressuredeficit_model_saturationvaporpressuredeficit', 'referenceevapotranspiration_model_referenceevapotranspiration', 'potentialevapotranspiration_model_potentialevapotranspiration', 'AMEIPotET']



saturationvaporpressuredeficit_model_saturationvaporpressuredeficit = Factory(name='SaturationVaporPressureDeficit',
                authors='AMEI Consortium (wralea authors)',
                description='\n        ',
                category='Unclassified',
                nodemodule='saturationvaporpressuredeficit',
                nodeclass='model_saturationvaporpressuredeficit',
                inputs=[{'name': 'saturated_vapor_pressure', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'vapor_pressure', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}],
                outputs=[{'name': 'saturation_vapor_pressure_deficit', 'interface': IFloat(min=0, max=16777216, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




referenceevapotranspiration_model_referenceevapotranspiration = Factory(name='ReferenceEvapotranspiration',
                authors='AMEI Consortium (wralea authors)',
                description='\n            A method following Penman-Monteith as described by the FAO in Allen\n            RG, Pereira LS, Raes D, Smith M. (1998) Crop evapotranspiration.\n            Guidelines for computing crop water requirements. FAO Irrigation and\n            Drainage Paper 56, FAO, Roma\n        ',
                category='Unclassified',
                nodemodule='referenceevapotranspiration',
                nodeclass='model_referenceevapotranspiration',
                inputs=[{'name': 'height_nn', 'interface': IFloat(min=-9999, max=9999, step=1.000000), 'value': 0}, {'name': 'latent_heat_of_vaporization', 'interface': IFloat(min=0, max=10, step=1.000000), 'value': 0}, {'name': 'mean_air_temperature', 'interface': IFloat(min=-100, max=100, step=1.000000), 'value': 0}, {'name': 'wind_speed', 'interface': IFloat(min=0, max=9999, step=1.000000), 'value': 0}, {'name': 'wind_speed_height', 'interface': IFloat(min=0, max=9999, step=1.000000), 'value': 2}, {'name': 'net_radiation', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}, {'name': 'stomata_resistance', 'interface': IFloat(min=0, max=10000, step=1.000000), 'value': 100}, {'name': 'saturation_vapor_pressure_deficit', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}],
                outputs=[{'name': 'reference_evapotranspiration', 'interface': IFloat(min=0, max=16777216, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




potentialevapotranspiration_model_potentialevapotranspiration = Factory(name='PotentialEvapotranspiration',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='potentialevapotranspiration',
                nodeclass='model_potentialevapotranspiration',
                inputs=[{'name': 'potential_evapotranspiration_cap', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 6.5}, {'name': 'kc_factor', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0.75}, {'name': 'developmental_stage', 'interface': IInt(min=0, max=6, step=1), 'value': 0}, {'name': 'crop_remaining_evapotranspiration', 'interface': IFloat, 'value': 0}, {'name': 'reference_evapotranspiration', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0}],
                outputs=[{'name': 'potential_evapotranspiration', 'interface': IFloat(min=0, max=16777216, step=1.000000)}],
                widgetmodule=None,
                widgetclass=None,
               )




AMEIPotET = CompositeNodeFactory(name='AMEIPotET',
                             description=('\n'
 '\n'
 '    AMEI ET MONICA potential evapotranspiration model\n'
 '    -Version: 1  -Time step: 1\n'
 '    Authors: Claas Nendel (transcription into Crop2ML by Michael '
 'Berg-Mohnicke)\n'
 '    Reference: None\n'
 '    Institution: ZALF e.V.\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: Calculates the MONICA potential evapotranspiration for '
 'AMEI ET exercise\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'vapor_pressure'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'saturated_vapor_pressure'},
   {  'interface': IFloat(min=-9999, max=9999, step=1.000000),
      'name': 'height_nn'},
   {  'interface': IFloat(min=0, max=10, step=1.000000),
      'name': 'latent_heat_of_vaporization'},
   {  'interface': IFloat(min=-100, max=100, step=1.000000),
      'name': 'mean_air_temperature'},
   {'interface': IFloat(min=0, max=9999, step=1.000000), 'name': 'wind_speed'},
   {  'interface': IFloat(min=0, max=9999, step=1.000000),
      'name': 'wind_speed_height',
      'value': 2},
   {  'interface': IFloat(min=0, max=10000, step=1.000000),
      'name': 'stomata_resistance',
      'value': 100},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'net_radiation'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'kc_factor',
      'value': 0.75},
   {'interface': IInt(min=0, max=6, step=1), 'name': 'developmental_stage'},
   {'interface': IFloat, 'name': 'crop_remaining_evapotranspiration'}],
                             outputs=[  {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'reference_evapotranspiration'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'potential_evapotranspiration'}],
                             elt_factory={  2: (  'amei.monica_evapotranspiration.ameipotet',
         'SaturationVaporPressureDeficit'),
   3: (  'amei.monica_evapotranspiration.ameipotet',
         'ReferenceEvapotranspiration'),
   4: (  'amei.monica_evapotranspiration.ameipotet',
         'PotentialEvapotranspiration')},
                             elt_connections={  111064956653992: (3, 0, '__out__', 0),
   111064956654024: (4, 0, '__out__', 1),
   111064956654056: ('__in__', 0, 2, 1),
   111064956654088: ('__in__', 1, 2, 0),
   111064956654120: ('__in__', 2, 3, 0),
   111064956654152: ('__in__', 3, 3, 1),
   111064956654184: ('__in__', 4, 3, 2),
   111064956654216: ('__in__', 5, 3, 3),
   111064956654248: ('__in__', 6, 3, 4),
   111064956654280: ('__in__', 7, 3, 6),
   111064956654312: ('__in__', 8, 3, 5),
   111064956654344: ('__in__', 9, 4, 1),
   111064956654376: ('__in__', 10, 4, 2),
   111064956654408: ('__in__', 11, 4, 3),
   111064956654440: (2, 0, 3, 7),
   111064956654472: (3, 0, 4, 4)},
                             elt_data={  2: {  'block': False,
         'caption': 'SaturationVaporPressureDeficit',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': -125,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   3: {  'block': False,
         'caption': 'ReferenceEvapotranspiration',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0.0,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'PotentialEvapotranspiration',
         'delay': 0,
         'hide': True,
         'id': 4,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 125.0,
         'posy': 125.0,
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
                             elt_value={2: [], 3: [], 4: [(0, '6.5')], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [-125, 125.0], 'userColor': None, 'useUserColor': True},
   3: {'position': [0.0, 125.0], 'userColor': None, 'useUserColor': True},
   4: {'position': [125.0, 125.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




