thisdir = scripts
include ../build/rules.make

bin_SCRIPTS = \
	$(scripts_3_0)

scripts_3_0 = \
	xamlc			\
	client-proxy-gen	\
	sts			\
	svcutil

DISTFILES =			\
	script.in

# FIXME: if we still want to use mint then we need switch like mono/scripts/Makefile.am
mono_interp = mono

ifeq ($(PLATFORM), win32)
	plat_bindir = `cygpath -m $(prefix)/bin`
	mono_instdir = `cygpath -m $(prefix)/lib/mono`
else
	plat_bindir = $(bindir)
	mono_instdir = $(prefix)/lib/mono
endif

REWRITE_COMMON = sed \
	-e 's,@''bindir@,$(bindir),g'				\
	-e 's,@''plat_bindir@,$(plat_bindir),g'			\
	-e 's,@''mono_instdir@,$(mono_instdir),g'		\
	-e 's,@''gtkdir@,$(gtkdir),g'

REWRITE = $(REWRITE_COMMON) -e 's,@''mono_interp@,$(mono_interp),g'
REWRITE_DEBUG = $(REWRITE_COMMON) -e 's,@''mono_interp@,$(mono_interp) --debug,g'

REWRITE3 = $(REWRITE) -e 's,@''framework_version@,2.0,g'
REWRITE3_DEBUG = $(REWRITE_DEBUG) -e 's,@''framework_version@,2.0,g'

.PHONY: $(scripts_3_0)
all-local:  $(scripts_3_0)

$(scripts_3_0): script.in Makefile
	n=`echo $@ | sed 's,2$$,,'`; \
	$(REWRITE3) -e "s,@""exe_name@,$$n,g" script.in > $@.tmp
	mv $@.tmp $@

install-local:
	$(MKINSTALLDIRS) $(DESTDIR)$(prefix)/bin
	$(INSTALL_BIN) $(scripts_3_0) $(DESTDIR)$(prefix)/bin

clean-local:
	rm -f $(scripts_3_0)

test-local:

dist-local: dist-default
distclean-local: distclean-default
