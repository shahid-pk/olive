thisdir = class/System.Workflow.Runtime
include ../../build/rules.make
SUBDIRS =

LIBRARY = System.Workflow.Runtime.dll

LIBRARY_USE_INTERMEDIATE_FILE = yes

# this c:/tmp no /cygdrive/tmp /r:/tmp/System.Workflow.ComponentModel.dll
LIB_MCS_FLAGS = /r:$(corlib) /r:System.dll /lib:../lib/net_3_0 /r:System.Workflow.ComponentModel.dll /r:System.Workflow.Activities /r:System.Xml /r:System.Transactions.dll /r:System.Configuration.dll
TEST_MCS_FLAGS =  $(LIB_MCS_FLAGS)

include ../../build/library.make







