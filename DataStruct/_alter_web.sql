
ALTER TABLE zService  ADD zImage varbinary(MAX);

ALTER TABLE zBranch  ADD zCountBooking INT DEFAULT ((10));
ALTER TABLE zBranch  ADD zIsSendMassage bit DEFAULT ((0));

ALTER TABLE zBranch 
ADD CONSTRAINT zBranch_zCountBooking
DEFAULT ((10)) FOR zCountBooking;

