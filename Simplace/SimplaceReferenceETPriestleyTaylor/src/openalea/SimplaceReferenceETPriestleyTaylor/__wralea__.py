
# -*- coding: latin-1 -*-
# This file has been generated at Thu Jan  8 15:47:01 2026

from openalea.core import *


__name__ = 'amei.simplace_.referenceetpriestleytaylor_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['ReferenceETPriestleyTaylor_']


__all__ = ['referenceetpriestleytaylor_model_referenceetpriestleytaylor', '_128085669396208']



referenceetpriestleytaylor_model_referenceetpriestleytaylor = Factory(name='ReferenceETPriestleyTaylor',
                authors='AMEI Consortium (wralea authors)',
                description='as given in the documentation',
                category='Unclassified',
                nodemodule='referenceetpriestleytaylor',
                nodeclass='model_referenceetpriestleytaylor',
                inputs=[{'name': 'cAltitude', 'interface': IFloat, 'value': 0.0}, {'name': 'cAlphaPT', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 1.26}, {'name': 'iTMax', 'interface': IFloat, 'value': 0.0}, {'name': 'iTMin', 'interface': IFloat, 'value': 0.0}, {'name': 'iNetRadiation', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'ReferenceCropEvapotranspiration', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




_128085669396208 = CompositeNodeFactory(name='ReferenceETPriestleyTaylor_',
                             description=('\n'
 '\n'
 '    ReferenceETPriestleyTaylor_ model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: Gunther Krauss\n'
 "    Reference: ('http://www.simplace.net/doc/simplace_modules/',)\n"
 '    Institution: INRES Pflanzenbau, Uni Bonn\n'
 '    ExtendedDescription: as given in the documentation\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat, 'name': 'iTMin'},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'cAlphaPT',
      'value': 1.26},
   {'interface': IFloat, 'name': 'iNetRadiation'},
   {'interface': IFloat, 'name': 'iTMax'},
   {'interface': IFloat, 'name': 'cAltitude'}],
                             outputs=[{'interface': IFloat, 'name': 'ReferenceCropEvapotranspiration'}],
                             elt_factory={  2: (  'amei.simplace_.referenceetpriestleytaylor_',
         'ReferenceETPriestleyTaylor')},
                             elt_connections={  97352480257256: (2, 0, '__out__', 0),
   97352480257288: ('__in__', 0, 2, 3),
   97352480257320: ('__in__', 1, 2, 1),
   97352480257352: ('__in__', 2, 2, 4),
   97352480257384: ('__in__', 3, 2, 2),
   97352480257416: ('__in__', 4, 2, 0)},
                             elt_data={  2: {  'block': False,
         'caption': 'ReferenceETPriestleyTaylor',
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




