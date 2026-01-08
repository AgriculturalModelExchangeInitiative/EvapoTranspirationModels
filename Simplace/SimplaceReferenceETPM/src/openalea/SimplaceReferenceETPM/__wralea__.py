
# -*- coding: latin-1 -*-
# This file has been generated at Thu Jan  8 15:57:32 2026

from openalea.core import *


__name__ = 'amei.simplace_.referenceetpm_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['ReferenceETPM_']


__all__ = ['referenceetpm_model_referenceetpm', '_139817644593504']



referenceetpm_model_referenceetpm = Factory(name='ReferenceETPM',
                authors='AMEI Consortium (wralea authors)',
                description='as given in the documentation',
                category='Unclassified',
                nodemodule='referenceetpm',
                nodeclass='model_referenceetpm',
                inputs=[{'name': 'cAltitude', 'interface': IFloat, 'value': 0.0}, {'name': 'iTMax', 'interface': IFloat, 'value': 0.0}, {'name': 'iTMin', 'interface': IFloat, 'value': 0.0}, {'name': 'iActualVapourPressure', 'interface': IFloat, 'value': 0.0}, {'name': 'iNetRadiation', 'interface': IFloat, 'value': 0.0}, {'name': 'iWindspeed', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'ReferenceCropEvapotranspiration', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




_139817644593504 = CompositeNodeFactory(name='ReferenceETPM_',
                             description=('\n'
 '\n'
 '    ReferenceETPM_ model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: Gunther Krauss\n'
 "    Reference: ('http://www.simplace.net/doc/simplace_modules/',)\n"
 '    Institution: INRES Pflanzenbau, Uni Bonn\n'
 '    ExtendedDescription: as given in the documentation\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat, 'name': 'iNetRadiation'},
   {'interface': IFloat, 'name': 'cAltitude'},
   {'interface': IFloat, 'name': 'iActualVapourPressure'},
   {'interface': IFloat, 'name': 'iTMax'},
   {'interface': IFloat, 'name': 'iTMin'},
   {'interface': IFloat, 'name': 'iWindspeed'}],
                             outputs=[{'interface': IFloat, 'name': 'ReferenceCropEvapotranspiration'}],
                             elt_factory={2: ('amei.simplace_.referenceetpm_', 'ReferenceETPM')},
                             elt_connections={  97981336515816: (2, 0, '__out__', 0),
   97981336515848: ('__in__', 0, 2, 4),
   97981336515880: ('__in__', 1, 2, 0),
   97981336515912: ('__in__', 2, 2, 3),
   97981336515944: ('__in__', 3, 2, 1),
   97981336515976: ('__in__', 4, 2, 2),
   97981336516008: ('__in__', 5, 2, 5)},
                             elt_data={  2: {  'block': False,
         'caption': 'ReferenceETPM',
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




