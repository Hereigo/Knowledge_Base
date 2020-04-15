<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="/">
    <Details>
      <From>
        <xsl:value-of select="note/from"/>
      </From>
      <To>
        <xsl:value-of select="note/to"/>
      </To>
      <Heading>
        <xsl:value-of select="concat(note/heading1,', ',note/heading2)" />
      </Heading>
    </Details>
  </xsl:template>
</xsl:stylesheet>
