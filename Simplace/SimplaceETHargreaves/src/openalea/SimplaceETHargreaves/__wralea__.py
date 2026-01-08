
# -*- coding: latin-1 -*-
# This file has been generated at Thu Jan  8 15:54:08 2026

from openalea.core import *


__name__ = 'amei.simplace_.referenceethargreaves_'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['ReferenceETHargreaves_']


__all__ = ['referenceethargreaves_model_referenceethargreaves', '_135362776835056']



referenceethargreaves_model_referenceethargreaves = Factory(name='ReferenceETHargreaves',
                authors='AMEI Consortium (wralea authors)',
                description='as given in the documentation',
                category='Unclassified',
                nodemodule='referenceethargreaves',
                nodeclass='model_referenceethargreaves',
                inputs=[{'name': 'cConvertLeByTemp', 'interface': IBool, 'value': 'False'}, {'name': 'iTMax', 'interface': IFloat, 'value': 0.0}, {'name': 'iTMin', 'interface': IFloat, 'value': 0.0}, {'name': 'iSolarRadiation', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'ReferenceCropEvapotranspiration', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




_135362776835056 = CompositeNodeFactory(name='ReferenceETHargreaves_',
                             description=('\n'
 '\n'
 '    ReferenceETHargreaves_ model\n'
 '    -Version: 001  -Time step: 1\n'
 '    Authors: Gunther Krauss\n'
 "    Reference: ('http://www.simplace.net/doc/simplace_modules/',)\n"
 '    Institution: INRES Pflanzenbau, Uni Bonn\n'
 '    ExtendedDescription: as given in the documentation\n'
 '    ShortDescription: None\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat, 'name': 'iTMax'},
   {'interface': IFloat, 'name': 'iSolarRadiation'},
   {'interface': IFloat, 'name': 'iTMin'},
   {'interface': IBool, 'name': 'cConvertLeByTemp', 'value': 'False'}],
                             outputs=[{'interface': IFloat, 'name': 'ReferenceCropEvapotranspiration'}],
                             elt_factory={2: ('amei.simplace_.referenceethargreaves_', 'ReferenceETHargreaves')},
                             elt_connections={  107781974357224: (2, 0, '__out__', 0),
   107781974357256: ('__in__', 0, 2, 1),
   107781974357288: ('__in__', 1, 2, 3),
   107781974357320: ('__in__', 2, 2, 2),
   107781974357352: ('__in__', 3, 2, 0)},
                             elt_data={  2: {  'block': False,
         'caption': 'ReferenceETHargreaves',
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




