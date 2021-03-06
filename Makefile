thisdir := .

# build is listed both at the beginning and end because the "clean"
# recursive target ends up *creating* files in build/deps, which need
# to be cleaned up during distcheck.

SUBDIRS := build class tools data scripts nunit24 build

net_3_0_SUBDIRS := build class tools data scripts nunit24 build

-include build/config.make

PROFILES = net_3_0 net_4_0

STD_TARGETS_OVERRIDE = all clean install uninstall test distclean

ifndef PROFILE
OVERRIDE_STD_TARGETS = yes
$(STD_TARGETS_OVERRIDE:=.override): %.override: profiles-do--%
endif

include build/rules.make

all-recursive $(STD_TARGETS:=-recursive): platform-check profile-check

.PHONY: all-local $(STD_TARGETS:=-local)
all-local $(STD_TARGETS:=-local):
	@:

DISTFILES = README configure mkinstalldirs nunit.key install-sh

# fun specialty targets

.PHONY: all-profiles $(STD_TARGETS:=-profiles)
all-profiles $(STD_TARGETS:=-profiles): %-profiles: profiles-do--%
	@:

profiles-do--%:
	$(MAKE) $(PROFILES:%=profile-do--%--$*)

# The % below looks like profile-name--target-name
profile-do--%:
	$(MAKE) PROFILE=$(subst --, ,$*)

# We don't want to run the tests in parallel.  We want behaviour like -k.
profiles-do--run-test:
	ret=:; $(foreach p,$(PROFILES), { $(MAKE) PROFILE=$(p) run-test || ret=false; }; ) $$ret

# Orchestrate the bootstrap here.
_boot_ = all clean install
$(_boot_:%=profile-do--net_2_0--%):           profile-do--net_2_0--%:           profile-do--net_2_0_bootstrap--%
$(_boot_:%=profile-do--net_2_0_bootstrap--%): profile-do--net_2_0_bootstrap--%: profile-do--default--%
$(_boot_:%=profile-do--default--%):           profile-do--default--%:           profile-do--net_1_1_bootstrap--%
$(_boot_:%=profile-do--net_1_1_bootstrap--%): profile-do--net_1_1_bootstrap--%: profile-do--basic--%

testcorlib:
	@cd class/corlib && $(MAKE) test run-test

compiler-tests:
	$(MAKE) TEST_SUBDIRS="tests errors" run-test-profiles

test-installed-compiler:
	$(MAKE) TEST_SUBDIRS="tests errors" PROFILE=default TEST_RUNTIME=mono MCS=mcs run-test
	$(MAKE) TEST_SUBDIRS="tests errors" PROFILE=net_2_0 TEST_RUNTIME=mono MCS=gmcs run-test

package := olive-$(OLIVE_VERSION)

dist-local: dist-default

dist-pre:
	rm -rf $(package)
	mkdir $(package)

dist-tarball: dist-pre
	$(MAKE) distdir='$(package)' dist-recursive
	tar cvjf $(package).tar.bz2 $(package)

dist: dist-tarball
	rm -rf $(package)

# the egrep -v is kind of a hack (to get rid of the makefrags)
# but otherwise we have to make dist then make clean which
# is sort of not kosher. And it breaks with DIST_ONLY_SUBDIRS.
#
# We need to set prefix on make so class/System/Makefile can find
# the installed System.Xml to build properly

distcheck: dist-tarball
	rm -rf InstallTest Distcheck-Olive ; \
	mkdir InstallTest ; \
	destdir=`cd InstallTest && pwd` ; \
	mv $(package) Distcheck-Olive ; \
	(cd Distcheck-Olive && \
	    ./configure --prefix=$(prefix) && \
	    $(MAKE) prefix=$(prefix) && $(MAKE) test && $(MAKE) install DESTDIR="$$destdir" && \
	    $(MAKE) clean && $(MAKE) dist && $(MAKE) distclean || exit 1) || exit 1 ; \
	mv Distcheck-Olive $(package) ; \
	tar tjf $(package)/$(package).tar.bz2 |sed -e 's,/$$,,' |sort >distdist.list ; \
	rm $(package)/$(package).tar.bz2 ; \
	tar tjf $(package).tar.bz2 |sed -e 's,/$$,,' |sort >before.list ; \
	find $(package) |egrep -v '(makefrag|response)' |sed -e 's,/$$,,' |sort >after.list ; \
	cmp before.list after.list || exit 1 ; \
	cmp before.list distdist.list || exit 1 ; \
	rm -f before.list after.list distdist.list ; \
	rm -rf $(package) InstallTest ; \
	echo "Distcheck of $(package) successful"

monocharge:
	chargedir=monocharge-`date -u +%Y%m%d` ; \
	mkdir "$$chargedir" ; \
	DESTDIR=`cd "$$chargedir" && pwd` ; \
	$(MAKE) install DESTDIR="$$DESTDIR" || exit 1 ; \
	tar cvjf "$$chargedir".tar.bz2 "$$chargedir" ; \
	rm -rf "$$chargedir"

# A bare-bones monocharge.

monocharge-lite:
	chargedir=monocharge-lite-`date -u +%Y%m%d` ; \
	mkdir "$$chargedir" ; \
	DESTDIR=`cd "$$chargedir" && pwd` ; \
	$(MAKE) -C mcs install DESTDIR="$$DESTDIR" || exit 1; \
	$(MAKE) -C class/corlib install DESTDIR="$$DESTDIR" || exit 1; \
	$(MAKE) -C class/System install DESTDIR="$$DESTDIR" || exit 1; \
	$(MAKE) -C class/System.XML install DESTDIR="$$DESTDIR" || exit 1; \
	$(MAKE) -C class/Mono.CSharp.Debugger install DESTDIR="$$DESTDIR" || exit 1; \
	tar cvjf "$$chargedir".tar.bz2 "$$chargedir" ; \
	rm -rf "$$chargedir"
