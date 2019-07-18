DELIMITER $$

DROP FUNCTION IF EXISTS `GuidToBinary`$$

CREATE FUNCTION `GuidToBinary`(
    $guid VARCHAR(36)
) RETURNS binary(16)
deterministic
BEGIN
    DECLARE $result BINARY(16) DEFAULT NULL;
    IF $guid IS NOT NULL THEN
        SET $guid = REPLACE($guid,'-','');
        SET $result = CONCAT(UNHEX(SUBSTRING($guid,7,2)),UNHEX(SUBSTRING($guid,5,2)),UNHEX(SUBSTRING($guid,3,2)), UNHEX(SUBSTRING($guid,1,2)),
                UNHEX(SUBSTRING($guid,11,2)),UNHEX(SUBSTRING($guid,9,2)),UNHEX(SUBSTRING($guid,15,2)) , UNHEX(SUBSTRING($guid,13,2)),
                UNHEX(SUBSTRING($guid,17,16)));
    END IF;
    RETURN $result;
END $$

DELIMITER ;