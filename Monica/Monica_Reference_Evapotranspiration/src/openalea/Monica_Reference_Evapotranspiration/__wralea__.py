
# -*- coding: latin-1 -*-
# This file has been generated at Fri Nov 27 11:36:19 2026

from openalea.core import *


__name__ = 'amei.monica_evapotranspiration.ameirefet'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['AMEIRefET']


__all__ = ['referenceevapotranspiration_model_referenceevapotranspiration', 'AMEIRefET']



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




AMEIRefET = CompositeNodeFactory(name='AMEIRefET',
                             description=('\n'
 '\n'
 '    AMEI ET MONICA reference evapotranspiration model\n'
 '    -Version: 1  -Time step: 1\n'
 '    Authors: Claas Nendel (transcription into Crop2ML by Michael '
 'Berg-Mohnicke)\n'
 '    Reference: None\n'
 '    Institution: ZALF e.V.\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: Calculates the MONICA reference evapotranspiration for '
 'AMEI ET exercise\n'),
                             category='',
                             doc='',
                             inputs=[  {  'interface': IFloat(min=-9999, max=9999, step=1.000000),
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
      'name': 'saturation_vapor_pressure_deficit'}],
                             outputs=[  {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'reference_evapotranspiration'}],
                             elt_factory={2: ('amei.monica_evapotranspiration.ameirefet', 'ReferenceEvapotranspiration')},
                             elt_connections={  97328474309032: (2, 0, '__out__', 0),
   97328474309064: ('__in__', 0, 2, 0),
   97328474309096: ('__in__', 1, 2, 1),
   97328474309128: ('__in__', 2, 2, 2),
   97328474309160: ('__in__', 3, 2, 3),
   97328474309192: ('__in__', 4, 2, 4),
   97328474309224: ('__in__', 5, 2, 6),
   97328474309256: ('__in__', 6, 2, 5),
   97328474309288: ('__in__', 7, 2, 7)},
                             elt_data={  2: {  'block': False,
         'caption': 'ReferenceEvapotranspiration',
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




