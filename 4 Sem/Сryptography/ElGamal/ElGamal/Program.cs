using System;
using System.Globalization;
using System.Numerics;

namespace ElGamal
{
    class Program
    {

        private static void Test1()
        {
            Console.WriteLine("=========================Test 1=========================");


            string hex = "3af217de2a4e10d271c04cb0b74f241dab688b427f44073c6187806eca480e1533e992a929d8bd764eda81d93784f645b5f534899e9a7056c4af839976702ba617a015728b7c2838f91613740363c1d8aa4d1ab45bd2ca5be0d0aa9b1dbea6439961534dee5e6aba09241465942c369ac367b2878fbc32ded2c9148e45c0dfa525f0f7356a64292c1303c7cd83ee49c8c6d735dc1e0ee1853cd72d59743277a19da0c539";
            var p = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "5d0b370a8719fa1d3d4766304591abd0a76ee325351e4dd8d";
            var q = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "26432148e72709b30e9ba0e47725e39ab0fd53dd89d5352fc510e4176860786954b7209bcbb885a3acac58a45c95c4cb02f8657ad374b4ba99d4a5b0cd5af93aa8821aee79c1057be3be452885be0735af46161d687e4284e85b5d0d4b672b0c8fc812573621823a9e13b75c7a17bfde22cdfc3b74c0bfba75c0e9b9f4bac16e14764d6772cd538eb454eb55f0e46f514b87726c340d9e8aba3d7ecd359739a48ebe7286";
            var g = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "1659c8af2d4293c2dd6c3f72d3b530b0967e055daef8caa02cfeca4b25de2dcd6a0dee4e4bc6f28590f45545986a0528bee6a5b07e73b5bb86c7312b1d5f58fc184fcdd9e2fc91d3004a491aee866dbf3cef174aac1b46d224fb1bf0286824d569159bb12429e62e4a35f5507cf5efbb8bc7055146d417e9d41217669999e5697a0c20871ca3680ff26330b8a74b6cf5dbf4cfc9a5f45b6a9007f277d1a702b64e3a014c";
            var r = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "435769b32e78c2116658549328eeeba56abdabb100f72ab8";
            var s = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "50ae71ca1ae2d150abfb70bf310226d43da09a057d998c4bea2f515ab25decb16ff4aa205b22041df7d9427d940320ae11e7e0088e86741117145af1d80389eb03e4081b68f243fbbf422eb7af5b7183631f8790d4ad2d8dcb1a9f0e9130b20f238d734d45e8e4a9079b88e70c6de36f0e5b22d0e8688ce7e17e77292d82286dd9f6719cf5d7ac10069b1f17a48849eb5f10050ec58d29bc27575a2a23d8fa69177d49";
            var y = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);
           
            hex = "5ae193f116303e72ec562bf6b6e3f42bfb54ae94d94e8fc7";
            var msg = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            ElGamalDigitalSignature cipher = new ElGamalDigitalSignature(p,g,y);

            Console.WriteLine($"X: {cipher.CheckSignature(msg,r,s, q).ToString()}");

        }

        private static void Test2()
        {
            Console.WriteLine("=========================Test 2=========================");
            string hex = "3c2950e9775a508124b295585480d7a8a1dacc38496a070debbe980516ab189bd6fa71779acf0e3e27864585a01f95bb89e178aff0ebf391245b85043a7fc34bfd20c28686cb7f4aaa90db71249efc10907b402ec98258f0ccf6bbaa3bbc50afa8d5f0aa5c86e425a3815efe4493aa59299e80ae4fb6fe7d3d26417873171dde0883dbea983015d18a04801272dbabc4ed2b9decc857336c19e0f68212de8474fe525e5d";
            var p = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "694b5234fbf354d3ffe23794a3eae152c044594875a72ada7";
            var q = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "23be0ddf68f821b621c3b9506a092f2ed7f24643fa03875019a49372bbb9854da936a9a13ff797322ab95a0753a0f0f08511734e481ac962f7ff7806d82edb84ccb6a7d2f3936526ab3f963d6bb1642d3bacc897e9cb0889be6de322d5ccfbc41d662b755549dd1076c30db1cbb7ec5c1c38e7d74e097b4e146c843bcc6274a6319263f6a6a12e96901ad540dd191444a4d63ae75f6e52b5ccb69417f0c131bfe3eec55b";
            var g = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "6a1eb9ad4073008e448d39b3677fc55a1d26ecb7839793f6217233513af5b4175f0382d36f5aee09a4a95f8d2f6608ba47059e4b4ae564c153d87b9e5ce1cd0489d86ad121215561c97c1c75f01f7b896913575bcc9604d7051abec4eb72b23815f01f2bbaee396450347465a15163112af13041e54e3e0e0b77a7eecced540b94cf9d415a22f54e750123aaa1048c29889f4d7f9d659b1cf9152aaf5d762b1b7c233d8";
            var r = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "8495df1434e61a704b8da629261c5826d3a2f68f458f1056c";
            var s = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "20092948177a3982259e64cd9c84d7dc5488a4422989b9f20d4512d0c52396f566d08c94565e3ec48aaa26ef6d2b8804dd82d4996c655855bf8e6bf3b0c0e18051209deb26f9d8cd437c16a9935c14f5d2998648c099d43e7e6013d12f0f1a778588aaa054f9e28d8b38a9f2f43b1e052fb5270be0f8310c8e563d4d328bb9a57c327b78bcb61cd8626d29b35fd9ebe69190e2d51bd52fd9c5c27fc8c24e61de489f4430";
            var y = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "2af75d9adf5d1eac879a44546ceff53abaa8a741d795582cf";
            var msg = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            ElGamalDigitalSignature cipher = new ElGamalDigitalSignature(p, g, y);

            Console.WriteLine($"X: {cipher.CheckSignature(msg, r, s, q).ToString()}");
        }

        private static void Test3()
        {
            Console.WriteLine("=========================Test 3=========================");
            string hex = "3ef0a4d2070c2133466e71ff0762d9fc5ff01a105e45611aefb1cd052e2ee7a6dd7ec6f245ad9319b01960efb64d9e46321ebea3ba8e51dad9b303e03ae6eb7f341d2e494031c4246dbcb82eb97efb8f51303d154b8d1c52f4951d8b51910a2d14fc6c4055d17b531c1887c309ec3e237ec78b3f3917af73aa21232f668311b0680b7c8dee86c5c332ba44ae05771eb7dd0d308d701ab5d22ca0c3bbebe929c1f33f4ed9";
            var p = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "72dc91350bf7377ab712451fd4ccb9301e4036da94b5c9251";
            var q = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "3ca72d2bdb19a19c04cf621a2a8aca819fc0d2085e0e721a1edb7d7a0e25204a5b8d4adb5c03c2a0cb634455d5cb16722808d146e5d454366c0f897a8b8be349d2a1928f65d5261df30a5cac185286499836ad4238597ee381edf8e6b75e1fd94d84a19beaa7866fabbca0bc439cabb7e22d6874b045ab6b2291e2b8039c2d4be6915f38a8930a93a8fbb3a4efe11f50430ee2d0b5bf21b5c8f2779a8dc07993956efa9f";
            var g = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "2bfa3c2936b8225d97165b582204585ff1b911f447b0dbcdf8179a6f3b537558183cbd7045ed26a236b031678e44b81eed6ec2d1d783304e6d22e94a67b75713d3fd8ee22326257088c2b294df86e9419d84b7377cc53b68296566f64f19a2086f2c336b40540fa98a51d6d7b85fc853eb5978290f19e0471009cd9c5972324f77a75da20b1a806bd611a8d7f16a584a49fa2efaa9e527a5347dac450dc1d4dc53a9d104";
            var r = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "029bf138aab25d8361225cfef137f496f8fbbdd4b33cb18bd9";
            var s = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "2fd6a2943e43159395b54b1c2308ec2936181edc69acbb1342cd5afd8f473f522b9f2ac89a154af7957382554632305a8d6f351c385dc37f602abafcbfb108a0dcf1ec594a6de84fc067de2dd102c571ecfa678610a824953ace31ad819fe5a39ca2389c2976b2331c13214d7e03644f0d4fb1e1449b4be59bcf3d84d46e22da92c462fb2a5da8e5b1c632547995cad2191af4a73b9c9aefe4b58ee906cf86375e191f6f";
            var y = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "52f44f7d0434d7d878bcbefe68990f14e7505034da41dc175";
            var msg = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            ElGamalDigitalSignature cipher = new ElGamalDigitalSignature(p, g, y);

            Console.WriteLine($"X: {cipher.CheckSignature(msg, r, s, q).ToString()}");
        }

        private static void Test4()
        {
            Console.WriteLine("=========================Test 4=========================");
            string hex = "3fa07e7275cc401c20a251b0865d5ae95ae736efadca87f48bfa78e7305842b2233c6bf19acab907e5c55314304d58a923b2be2579066dca3209b5a158020b284256489807530bb37c3658b2750b0ba3db6c841470e983030dd5ed3705b2ed2f45dc8fa3f27dfd442c5bd0315caa48637784cfbe8e2540abd6f24c5fc319887d6ec420cba965296ddc3a01586666d3fad1afb7663cd8ba771a7dea3b8727c36322fff221";
            var p = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "7abc6b40ae2b16bf2c05150d3b233df53d9727ac218d03f11";
            var q = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "30dfa2b3b3391407a78a291151e8b92657ae7591948e7edf3d229b97d0f8bd238eddc517b3b361d506ac5a4cd9428262098b317fa6f3316175bde2d804288add91b278aae5f5c93e48f17d8922dc9c643a8efc58cf7cf324a32148cae13cbc776d822ba3a091815c20b770b33dd1429bc73a14b3212f277aa5071466de73d366e0f46fcb36cd297b7cf9a5997276db3a79424ae48e4d530adca8e01fa2c80a19e2037afe";
            var g = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "484c567e4844d2070f8dc81832257bb32ac62209c7125d672";
            var msg = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "4e5edcb6d624f019a37134c5db7014dea0feaa4e4bd448e62";
            var x = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            hex = "27567cc30a70919c75a79e037d677f6f31d5501fd333317eb";
            var k = BigInteger.Parse(hex, NumberStyles.AllowHexSpecifier);

            ElGamalDigitalSignature cipher = new ElGamalDigitalSignature(p, g, x, k);
            var digital = cipher.GetDigital(msg, q);

            Console.WriteLine($"r: {digital[0].ToString("x")}");
            Console.WriteLine($"s: {digital[1].ToString("x")}");
        }


        static void Main(string[] args)
        {
            ElGamalDigitalSignature cipher = new ElGamalDigitalSignature(0);

            var crypt = cipher.EnCrypt(5);
            var decrypt = cipher.DeCrypt(crypt);

            Test1();
            Test2();
            Test3();
            Test4();
            Console.ReadKey();
        }
    }
}
