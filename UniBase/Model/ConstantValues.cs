namespace UniBase.Model
{
    class ConstantValues
    {

        private double _minWeight = 37;
        private double _maxWeight = 38.5;
        private double _minMipMa = 24;
        private double _maxMipMa = 26.5;
        private double _minLudkoncentration = 1;
        private double _maxLudkoncentration = 2;

        public double MinWeight { get => _minWeight; set => _minWeight = value; }
        public double MaxWeight { get => _maxWeight; set => _maxWeight = value; }
        public double MinMipMa { get => _minMipMa; set => _minMipMa = value; }
        public double MaxMipMa { get => _maxMipMa; set => _maxMipMa = value; }
        public double MinLudkoncentration { get => _minLudkoncentration; set => _minLudkoncentration = value; }
        public double MaxLudkoncentration { get => _maxLudkoncentration; set => _maxLudkoncentration = value; }



    }
}
