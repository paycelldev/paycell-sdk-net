using System;

namespace paycell_web_sdk_client.Util
{
    public static class UniqueIdGenerator
    {

        private static int sequence = 0;

        /**
         * Generates 20 digist ID from sequence
         * @return generated id
         */
        public static string GenerateTransactionId()
        {
            sequence = sequence + 1;
            return sequence.ToString("D20");
        }

        public static string KeyGenerator()
        {
            return Guid.NewGuid().ToString().Replace("{", "");
        }
    }

}