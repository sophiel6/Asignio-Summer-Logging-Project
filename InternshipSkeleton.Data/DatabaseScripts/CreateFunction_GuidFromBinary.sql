DELIMITER $$

/*
Utility function for viewing Guids in table fields.
*/
DROP FUNCTION IF EXISTS `GuidFromBinary`$$

CREATE FUNCTION `GuidFromBinary`(_bin BINARY(16)) RETURNS char(36) CHARSET utf8
deterministic
RETURN

	concat(
		hex(substr(_bin, 4, 1)),
		hex(substr(_bin, 3, 1)),
		hex(substr(_bin, 2, 1)),
		hex(substr(_bin, 1, 1)),
		'-',
		hex(substr(_bin, 6, 1)),
		hex(substr(_bin, 5, 1)),
		'-',
		hex(substr(_bin, 8, 1)),
		hex(substr(_bin, 7, 1)),
		'-',
		hex(substr(_bin, 9, 1)),
		hex(substr(_bin, 10, 1)),
		'-',
		hex(substr(_bin, 11, 8))
	)$$
DELIMITER ;